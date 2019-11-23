using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectLocation : MonoBehaviour {

	public GameObject[] notCurrentLocationButtons;
	public Sprite thisOne, notThisOne;
	[SerializeField]
	private string nameOfLocation;

	void Start () {
		if (!PlayerPrefs.HasKey ("Location"))
			PlayerPrefs.SetString ("Location", "Dark");
		if (PlayerPrefs.GetString ("Location") == nameOfLocation) {
			gameObject.transform.GetChild (0).transform.GetComponent <Image> ().sprite = thisOne;
		} else {
			gameObject.transform.GetChild (0).transform.GetComponent <Image> ().sprite = notThisOne;
		}
	}

	void OnMouseUpAsButton () {
		PlayerPrefs.SetString ("Location", nameOfLocation);

		for (int i = 0; i < notCurrentLocationButtons.Length; i++)
			notCurrentLocationButtons [i].GetComponent <Image> ().sprite = notThisOne;
		gameObject.transform.GetChild (0).GetComponent <Image> ().sprite = thisOne;
	}

}
