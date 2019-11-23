using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewLocation : MonoBehaviour {

	//public AudioSource soundObj;
	//public AudioClip success, fail;
	public GameObject checkedButton;
	public Sprite unchekedButton, checkedButtonSprite;
	public GameObject[] notCurrentLocationButtons;
	public GameObject[] buttonsToDisable;
	public Text coins;
	[SerializeField]
	private int price;
	[SerializeField]
	private string nameOfLocation;

	void Awake () {
		if (PlayerPrefs.GetString (nameOfLocation) == "Open") {
			for (int i = 0; i < buttonsToDisable.Length; i++)
				buttonsToDisable [i].SetActive (false);
			checkedButton.SetActive (true);
		}
			
	}

	void OnMouseUpAsButton () {
		if (PlayerPrefs.GetInt ("Coins") >= price) {
			//if (PlayerPrefs.GetString ("Music") != "no") {
			//	soundObj.clip = success;
			//	soundObj.Play ();
			//}
			PlayerPrefs.SetString ("Location", nameOfLocation);
			PlayerPrefs.SetString (nameOfLocation, "Open");
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - price);
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
			for (int i = 0; i < buttonsToDisable.Length; i++)
				buttonsToDisable [i].SetActive (false);

			for (int i = 0; i < notCurrentLocationButtons.Length; i++)
				notCurrentLocationButtons [i].GetComponent <Image> ().sprite = unchekedButton;
			checkedButton.SetActive (true);
			checkedButton.transform.GetChild (0).GetComponent <Image> ().sprite = checkedButtonSprite;

	//	Все закомментированно, так как в игре нет плагина Ultimate Mobile, если его добавить, то код будет рабочим
//			if (nameOfLocation == "City")
//				UM_GameServiceManager.Instance.UnlockAchievement("OpenCity");
//			else if (nameOfLocation == "Downtown")
//				UM_GameServiceManager.Instance.UnlockAchievement("OpenDowntown");
		//} else {
		//	if (PlayerPrefs.GetString ("Music") != "no") {
			//	soundObj.clip = fail;
			//	soundObj.Play ();
			//}
		}
	}

}
