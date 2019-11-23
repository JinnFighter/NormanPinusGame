using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondStep : MonoBehaviour {

	public Text study;

	void Start () {
		study.text = "Watch where the car turns";
	}

	void OnDisable () {
		PlayerPrefs.SetString ("Study", "Done");
		SceneManager.LoadScene ("game");
	}

}
