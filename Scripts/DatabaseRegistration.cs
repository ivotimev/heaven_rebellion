using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DatabaseRegistration : MonoBehaviour {

	public GameObject regPanel;
	public InputField usernameField;
	public InputField passwordField;
	public InputField nameField;
	public InputField re_passwordField;

	private string repassword = "";
	private string password = "";
	public string username = "";
	public string name = "";
	 
	public GameObject panel;
	public Text annotation;

	public void register () {
		name = nameField.text.Replace(" ","_");
		username = usernameField.text;
		password = passwordField.text;
		repassword = re_passwordField.text;
		bool everythingAlright = true;

		if (name == "") {
			panel.SetActive(true);
			annotation.text = "Please enter your name and last name!";
			everythingAlright = false;
			return;
		}

		if (username == "") {
			panel.SetActive(true);
			annotation.text = "Please enter a username!";
			everythingAlright = false;
			return;
				}
						
		if (password == "") {
			panel.SetActive(true);
			annotation.text = "Please enter a password!";
			everythingAlright = false;
			return;
				}
						
		if (repassword != password) {
			panel.SetActive(true);
			annotation.text = "Passwords don't match!";
			everythingAlright = false;
			return;
				}

		if(name.Length <= 8 || name.Length >=23 || username.Length <= 4 || username.Length >= 13 || password.Length <= 6 || password.Length >= 17)
		{
			panel.SetActive(true);
			annotation.text = "Make sure your name is between 9 and 22 symbols, your username between 5 and 12, and your password between 7 and 16!";
			everythingAlright = false;
			return;
		}

		for (int i = 0; i < name.Length; i++) {
			if(!((int)name[i] >= 65 && (int)name[i] <= 90 || (int)name[i] >= 97 && (int)name[i] <= 122 || name[i] == '_'))
			{
				panel.SetActive(true);
				annotation.text = "Your name should only contain your first and last names separated by an interval!";
				everythingAlright = false;
				return;
			}
				}

		for (int i = 0; i < username.Length; i++) {
			if(!((int)username[i] >= 65 && (int)username[i] <= 90 || (int)username[i] >= 97 && (int)username[i] <= 122 || (int)username[i] >= 48 && (int)username[i] <= 57 || (int)username[i] == 95))
			{
				panel.SetActive(true);
				annotation.text = "Your username can only contain letters, numbers or a '_'!";
				everythingAlright = false;
				return;
			}
		}

		if (everythingAlright) {
			WWWForm form = new WWWForm ();
			form.AddField ("username", username);
			form.AddField ("name", name);
			form.AddField ("password", password);
			WWW w = new WWW ("http://heaven.pmg-blg.com/register.php", form);
			StartCoroutine (register (w));


				}
	}

	IEnumerator register(WWW w)
	{
		yield return w;
		if (w.error == null) {
			panel.SetActive(true);
			annotation.text = w.text;

				if(w.text == "Sucessfully created user!")
				{
					usernameField.text = "";
					nameField.text = "";
					passwordField.text = "";
					re_passwordField.text = "";
					regPanel.SetActive(false);
				}
			}
	}	
}
