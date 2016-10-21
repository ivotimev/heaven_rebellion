using UnityEngine;
using System.Collections;
using System;

public class Password : MonoBehaviour {

	string passwordToEdit = String.Empty;

	void OnGUI()
	{
		passwordToEdit = GUI.PasswordField (new Rect (300, 300, 200, 20), passwordToEdit, "*" [0], 25);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
