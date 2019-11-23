using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuySlowTime : MonoBehaviour {

	//public AudioClip success, fail;
	public Text count, coins;

	void Start () {
		count.text = PlayerPrefs.GetInt ("Slow Time").ToString ();
	}

	void OnMouseUpAsButton () {
		if (PlayerPrefs.GetInt ("Coins") > 100) {
			PlayerPrefs.SetInt ("Slow Time", PlayerPrefs.GetInt ("Slow Time") + 1);
			count.text = PlayerPrefs.GetInt ("Slow Time").ToString ();
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 100);
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
			//if (PlayerPrefs.GetString ("Music") != "no") {
			//	gameObject.transform.GetChild (0).GetComponent <AudioSource> ().clip = success;
			//	gameObject.transform.GetChild (0).GetComponent <AudioSource> ().Play ();
		//	}
		//} else {
			//if (PlayerPrefs.GetString ("Music") != "no") {
			//	gameObject.transform.GetChild (0).GetComponent <AudioSource> ().clip = fail;
				//gameObject.transform.GetChild (0).GetComponent <AudioSource> ().Play ();
			//}
		}
	}

}
