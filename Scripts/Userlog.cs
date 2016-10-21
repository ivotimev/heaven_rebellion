using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Userlog : MonoBehaviour {
	// Use this for initialization
	public Text usernameInfo;

	void Awake ()
	{
		usernameInfo.text = string.Format ("Logged in as {0}, High Score: {1}", PlayerPrefs.GetString ("Username"), PlayerPrefs.GetInt("High Score"));
	}
}
