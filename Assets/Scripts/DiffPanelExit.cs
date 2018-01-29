using UnityEngine;
using System.Collections;

public class DiffPanelExit : MonoBehaviour {
	
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
	}
}
