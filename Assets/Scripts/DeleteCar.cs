using UnityEngine;

public class DeleteCar : MonoBehaviour {

	public static int countCars;

	void Start () {
		countCars = 0;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			if (!CollisionCars.lose) {
				countCars++;
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1);
			}
			Destroy (other.gameObject);
		}
	}

}

