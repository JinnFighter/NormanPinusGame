using System.Collections;
using UnityEngine;


[RequireComponent (typeof (MoveCar))]
public class WestTurnLeft : MonoBehaviour {

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
		if (transform.localPosition.x > 118f && carRotation > 180f) {
			if (carRotation > 180f && carRotation <= 184f) {
				transform.localRotation = Quaternion.Euler (new Vector3 (0, 180f, 0));
				return;
			}
			eulerAngleVelocity = GetComponent <MoveCar> ().speed * -8.57f;
			Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eulerAngleVelocity, 0) * Time.fixedDeltaTime);
			rb.MoveRotation (rb.rotation * deltaRotation);
		}
	}

}
