using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour {
	
	[SerializeField]
	private Text topRecord;

	void OnEnable () {
		GetComponent <Text> ().text = "Score: " + DeleteCar.countCars.ToString ();
		if (PlayerPrefs.GetInt ("Score") < DeleteCar.countCars) {
			PlayerPrefs.SetInt ("Score", DeleteCar.countCars);
			topRecord.text = "Top: " + DeleteCar.countCars.ToString ();

		} else
			topRecord.text = "Top: " + PlayerPrefs.GetInt ("Score").ToString ();
		
	}
}
