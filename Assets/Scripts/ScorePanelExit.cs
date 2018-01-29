using UnityEngine;
using System.Collections;

public class ScorePanelExit : MonoBehaviour {

	public GameObject menuPanel;
		public GameObject scorePanel;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			scorePanel.SetActive(false);
			scorePanel.transform.Find ("SurePanel").gameObject.SetActive(false);
			menuPanel.SetActive(true);
		}
	}
}
