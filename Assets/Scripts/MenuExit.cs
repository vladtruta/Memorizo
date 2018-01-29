using UnityEngine;
using System.Collections;

public class MenuExit : MonoBehaviour {

	public GameObject exitGame;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			exitGame.SetActive(true);
	}
}
