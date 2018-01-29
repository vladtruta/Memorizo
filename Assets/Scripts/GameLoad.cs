using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLoad : MonoBehaviour {


	public Text easyMoves;
	public Text easyRank;
	public Text mediumMoves;
	public Text mediumRank;
	public Text hardMoves;
	public Text hardRank;

	public void LoadDiff()
	{
		Application.LoadLevel(1);
	}
	public void LoadMenu()
	{
		Application.LoadLevel(0);
	}

	public void ScoreDisplay ()
	{
		easyMoves.text = PlayerPrefs.GetInt ("EasyMoves").ToString();
		easyRank.text = PlayerPrefs.GetString ("EasyRank");
		mediumMoves.text = PlayerPrefs.GetInt ("MediumMoves").ToString();
		mediumRank.text = PlayerPrefs.GetString ("MediumRank");
		hardMoves.text = PlayerPrefs.GetInt ("HardMoves").ToString();
		hardRank.text = PlayerPrefs.GetString ("HardRank");
	}
	
	public void ResetScore()
	{
		PlayerPrefs.DeleteAll();
		ScoreDisplay ();
	}
	public void Exit()
	{
		Application.Quit();
	}
}
