using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{

	Text moves;
	Text rank;
	GameObject congratsMenu;
	public AdMob admob;
	public GameObject pauseGame;

	void Awake ()
	{
		moves = this.transform.Find ("CongratsMenu/moves").GetComponent<Text> ();
		rank = this.transform.Find ("CongratsMenu/rank").GetComponent<Text> ();
		congratsMenu = this.transform.Find ("CongratsMenu").gameObject;
	
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)&&!congratsMenu.activeSelf)
			pauseGame.SetActive (true);

	}

	public void Finish (string diff)
	{
		congratsMenu.SetActive (true);
		moves.text = Scorehandler.moves.ToString ();
		
		if (diff == "easy") {
			if ((Scorehandler.moves <= 84 && Scorehandler.moves > 72) || Scorehandler.moves > 84)
				rank.text = "F";
			if (Scorehandler.moves <= 72)
				rank.text = "E";
			if (Scorehandler.moves <= 60)
				rank.text = "D";
			if (Scorehandler.moves < 48)
				rank.text = "C";
			if (Scorehandler.moves <= 36)
				rank.text = "B";
			if (Scorehandler.moves <= 24)
				rank.text = "A";

			if (PlayerPrefs.GetInt ("EasyMoves") == 0) {
				PlayerPrefs.SetInt ("EasyMoves", Scorehandler.moves);
				PlayerPrefs.SetString ("EasyRank", rank.text);
			} else if (Scorehandler.moves < PlayerPrefs.GetInt ("EasyMoves") && PlayerPrefs.GetInt ("EasyMoves") != 0) {
				PlayerPrefs.SetInt ("EasyMoves", Scorehandler.moves);
				PlayerPrefs.SetString ("EasyRank", rank.text);
			}	

		} else if (diff == "medium") {

			if ((Scorehandler.moves <= 108 && Scorehandler.moves > 96) || Scorehandler.moves > 108)
				rank.text = "F";
			if (Scorehandler.moves <= 96)
				rank.text = "E";
			if (Scorehandler.moves <= 84)
				rank.text = "D";
			if (Scorehandler.moves < 72)
				rank.text = "C";
			if (Scorehandler.moves <= 60)
				rank.text = "B";
			if (Scorehandler.moves <= 48)
				rank.text = "A";

			if (PlayerPrefs.GetInt ("MediumMoves") == 0) {
				PlayerPrefs.SetInt ("MediumMoves", Scorehandler.moves);
				PlayerPrefs.SetString ("MediumRank", rank.text);
			} else if (Scorehandler.moves < PlayerPrefs.GetInt ("MediumMoves") && PlayerPrefs.GetInt ("MediumMoves") != 0) {
				PlayerPrefs.SetInt ("MediumMoves", Scorehandler.moves);
				PlayerPrefs.SetString ("MediumRank", rank.text);
			}	

		} else if (diff == "hard") {

			if ((Scorehandler.moves <= 156 && Scorehandler.moves > 144) || Scorehandler.moves > 156)
				rank.text = "F";
			if (Scorehandler.moves <= 144)
				rank.text = "E";
			if (Scorehandler.moves <= 132)
				rank.text = "D";
			if (Scorehandler.moves < 120)
				rank.text = "C";
			if (Scorehandler.moves <= 108)
				rank.text = "B";
			if (Scorehandler.moves <= 96)
				rank.text = "A";

			if (PlayerPrefs.GetInt ("HardMoves") == 0) {
				PlayerPrefs.SetInt ("HardMoves", Scorehandler.moves);
				PlayerPrefs.SetString ("HardRank", rank.text);
			} else if (Scorehandler.moves < PlayerPrefs.GetInt ("HardMoves") && PlayerPrefs.GetInt ("HardMoves") != 0) {
				PlayerPrefs.SetInt ("HardMoves", Scorehandler.moves);
				PlayerPrefs.SetString ("HardRank", rank.text);
			}	
		}
		admob.ShowInterstitial ();
	}
}
