using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

	Image image;
	Button button;
	int buttonsActive;
	public static GameObject[] twoActive = new GameObject[2];

	void Start ()
	{
		button = gameObject.GetComponent<Button> ();
		image = transform.Find ("Image").GetComponent<Image> ();
		button.onClick.AddListener (() => {
			image.enabled=true;
			Scorehandler.moves++;

			if (twoActive [0] != null && twoActive [1] != null) {
				twoActive [0].transform.Find ("Image").GetComponent<Image>().enabled=false;
				twoActive [1].transform.Find ("Image").GetComponent<Image>().enabled=false;
				Reset (false);
				Add (this.gameObject);
			} else 
			{
				Add (this.gameObject);
				print (Scorehandler.moves);
			}
			//Scorehandler.moves++;
		});  
	}

	void Add (GameObject gob)
	{
		if (twoActive [0] == null) {
			twoActive [0] = gob;
			twoActive [0].GetComponent<Button> ().interactable = false;
		} else if ((twoActive [0] != null && twoActive [1] == null)||(twoActive [0] == null && twoActive [1] != null)) {
			twoActive [1] = gob;
			twoActive [0].GetComponent<Button> ().interactable = false;
			twoActive [1].GetComponent<Button> ().interactable = false;
			Check ();
			CheckFinish ();
		}


	}

	void Check ()
	{
		if (twoActive [0].transform.Find ("Image").gameObject.GetComponent<Image> ().sprite.name == twoActive [1].transform.Find ("Image").gameObject.GetComponent<Image> ().sprite.name) {
			twoActive [0].GetComponent<Button> ().interactable = false;
			twoActive [1].GetComponent<Button> ().interactable = false;
			Scorehandler.scoreCounter += 2;
			Reset (true);
		}	
	}

	void CheckFinish ()
	{
		if (Scorehandler.difficulty == "easy" && Scorehandler.scoreCounter == 12) {
			gameObject.transform.parent.transform.parent.GetComponent<FinishGame> ().Finish ("easy");
		} else if (Scorehandler.difficulty == "medium" && Scorehandler.scoreCounter == 24) {
			gameObject.transform.parent.transform.parent.GetComponent<FinishGame> ().Finish ("medium");
		} else if (Scorehandler.difficulty == "hard" && Scorehandler.scoreCounter == 48) {
			gameObject.transform.parent.transform.parent.GetComponent<FinishGame> ().Finish ("hard");
		}
	}

	public void Reset (bool isFinish)
	{
		if (!isFinish) {
			twoActive [0].GetComponent<Button> ().interactable = true;
			twoActive [1].GetComponent<Button> ().interactable = true;
		}
		twoActive [0] = null;
		twoActive [1] = null;
	}

	void FinishGame ()
	{



	}
}



