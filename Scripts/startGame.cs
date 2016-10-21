using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {

	// Use this for initialization
	public void playGame()
	{
		Time.timeScale = 1;
		Application.LoadLevel (2);
	}
}
