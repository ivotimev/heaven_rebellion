using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SetHighScores : MonoBehaviour {

	string[] userHighScores;
	string currentOutput = "";

	int currentId = 1;
	// Use this for initialization
	void Start () {
	    do {
			getHighScores(currentId);
			currentId += 1;
				} while(currentOutput != "ID does not exist!");
	}

    void getHighScores(int id)
    {
		WWWForm form = new WWWForm ();
		form.AddField ("ID", id);
		WWW w = new WWW ("http://cronogames.dx.am/setHighScores.php", form);
		StartCoroutine (loginFunc (w));
    }

	IEnumerator loginFunc(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			GetComponent<Text>().text += w.text;
			currentOutput = w.text;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
