using System.Collections;
using UnityEngine;

[RequireComponent (typeof (MoveCar))]
public class NorthTurnRight : MonoBehaviour {

	private Rigidbody rb;
	private float eulerAngleVelocity;

	void Start () {
		rb = GetComponent <Rigidbody> ();
	}

	void FixedUpdate () {
		leftTurn ();
	}

	void leftTurn () {
		float carRotation = Mathf.Floor (transform.eulerAngles.y);
		if (transform.localPosition.z < 57f && carRotation != 90f) {
			if (carRotation >= 89f && carRotation <= 94f) {
				transform.localRotation = Quaternion.Euler (new Vector3 (0, 90f, 0));
				return;
			}
			eulerAngleVelocity = GetComponent <MoveCar> ().speed * 8.57f;
			Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eulerAngleVelocity, 0) * Time.fixedDeltaTime);
			rb.MoveRotation (rb.rotation * deltaRotation);
		}
	}

}
