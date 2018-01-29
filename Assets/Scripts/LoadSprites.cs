using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSprites : MonoBehaviour
{

	struct Visited
	{
		public bool visited;
	}

	struct VisitedCount
	{
		public int visitedCount;
	}

	public Sprite[] spriteList;
	Visited[] spriteVisited = new Visited[30];
	Transform[] easySprites = new Transform[12];
	Transform[] medSprites = new Transform[24];
	Transform[] hardSprites = new Transform[48];



	void Awake ()
	{
		for (int i=0; i<12; i++)
			easySprites [i] = transform.Find ("Game/Easy/Button" + (i + 1).ToString ()).GetComponent<Transform> ();
		for (int i=0; i<24; i++)
			medSprites [i] = transform.Find ("Game/Medium/Button" + (i + 1).ToString ()).GetComponent<Transform> ();
		for (int i=0; i<48; i++)
			hardSprites [i] = transform.Find ("Game/Hard/Button" + (i + 1).ToString ()).GetComponent<Transform> ();

		//LoadSprite("easy");

	}

	public void LoadSprite (string diff)
	{

		//Reset ();


		Scorehandler.moves = 0;
		Scorehandler.scoreCounter = 0;
		Scorehandler.difficulty = null;
		ButtonHandler.twoActive[0]=null;
		ButtonHandler.twoActive[1]=null;


		if (diff == "easy") {

			easySprites [0].transform.parent.gameObject.SetActive (true);
			Scorehandler.difficulty = "easy";

			int [] randomPics = new int[6];
			Randomize (6, randomPics);
			Sprite[] easyS = new Sprite[12];	
			RandomizePositions (randomPics, easyS);


			int i;

			for (i=0; i<12; i++) {
				//easySprites [i].transform.Find ("Image").gameObject.SetActive(true);
				easySprites [i].transform.Find ("Image").GetComponent<Image> ().sprite = easyS [i];
			}
		} else if (diff == "medium") {

			medSprites [0].transform.parent.gameObject.SetActive (true);
			Scorehandler.difficulty = "medium";

			int [] randomPics = new int[12];
			Randomize (12, randomPics);
			Sprite[] medS = new Sprite[24];	
			RandomizePositions (randomPics, medS);
			
			
			int i;
			
			for (i=0; i<24; i++) {
				//medSprites [i].transform.Find ("Image").gameObject.SetActive(true);
				medSprites [i].transform.Find ("Image").GetComponent<Image> ().sprite = medS [i];
			}
		} else if (diff == "hard") {

			hardSprites [0].transform.parent.gameObject.SetActive (true);
			Scorehandler.difficulty = "hard";

			int [] randomPics = new int[24];
			Randomize (24, randomPics);
			Sprite[] hardS = new Sprite[48];	
			RandomizePositions (randomPics, hardS);
			
			
			int i;
			
			for (i=0; i<48; i++) {
				//hardSprites [i].transform.Find ("Image").gameObject.SetActive(true);
				hardSprites [i].transform.Find ("Image").GetComponent<Image> ().sprite = hardS [i];
			}
		}


	}

	void Randomize (int number, int[] par)
	{
		int i;
	
		int random;

		for (i=0; i<number; i++) {
			do {
				random = Random.Range (0, spriteList.Length);
				par [i] = random;
			} while (spriteVisited[random].visited==true);

			spriteVisited [par [i]].visited = true;
		}
	}

	void RandomizePositions (int[] randomPics, Sprite[] easyS)
	{
		VisitedCount[] visitedCount = new VisitedCount[randomPics.Length];
		int random;

		int i;

		for (i=0; i<easyS.Length; i++) {
			do {
				random = Random.Range (0, randomPics.Length);
				easyS [i] = spriteList [randomPics [random]];
			} while (visitedCount[random].visitedCount>=2);

			visitedCount [random].visitedCount++;
		}

	}

	public void Reset ()
	{
		int i;
		easySprites [0].transform.parent.gameObject.SetActive (false);
		medSprites [0].transform.parent.gameObject.SetActive (false);
		hardSprites [0].transform.parent.gameObject.SetActive (false);

		Scorehandler.moves = 0;
		Scorehandler.scoreCounter = 0;
		Scorehandler.difficulty = null;
		ButtonHandler.twoActive[0]=null;
		ButtonHandler.twoActive[1]=null;

		for (i=0; i<12; i++){
			easySprites [i].transform.Find ("Image").gameObject.SetActive (false);
			easySprites [i].GetComponent<Button>().interactable=false;
			easySprites [i].GetComponent<Button>().interactable=true;
		}

		for (i=0; i<24; i++){
			medSprites [i].transform.Find ("Image").gameObject.SetActive (false);
			medSprites [i].GetComponent<Button>().interactable=false;
			medSprites [i].GetComponent<Button>().interactable=true;
		}
		for (i=0; i<48; i++){
			hardSprites [i].transform.Find ("Image").gameObject.SetActive (false);
			hardSprites [i].GetComponent<Button>().interactable=false;
			hardSprites [i].GetComponent<Button>().interactable=true;
		}
		for (i=0; i<spriteVisited.Length; i++)
			spriteVisited [i].visited = false;


	}

	public void Exit ()
	{
		Application.Quit ();
	}
	


}
