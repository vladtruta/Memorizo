using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpMenu : MonoBehaviour {

	//Text time;
	Text moves;

	void Awake () {
		//time=transform.Find ("TimeLeft").GetComponent<Text>();
		moves=transform.Find ("Moves").GetComponent<Text>();
	}
	

	void Update () {
		moves.text=Scorehandler.moves.ToString();
	}
}
