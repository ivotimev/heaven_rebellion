using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour {

	public InputField usernameField;
	public InputField passwordField;
	public GameObject panel;
	public Text annotation;

	public string username;
	private string password;
	// Use this for initialization
	public void Login()
	{
		username = usernameField.text;
		password = passwordField.text;
		bool everythingAlright = true;

		if (usernameField.text == "") {
			panel.SetActive(true);
			annotation.text = "Please enter a username!";
				everythingAlright = false;
			return;
		}
				
		if (passwordField.text == "") {
			panel.SetActive(true);
			annotation.text = "Please enter a password!";
			everythingAlright = false;
			return;
		}

		if (everythingAlright) {
			WWWForm form = new WWWForm ();
			form.AddField ("username", username);
			form.AddField ("password", password);
			WWW w = new WWW ("http://heaven.pmg-blg.com/login.php", form);
			StartCoroutine (loginFunc (w));
					
			WWWForm form1 = new WWWForm ();
			form1.AddField ("username", username);
			WWW w1 = new WWW ("http://heaven.pmg-blg.com/takeHighScore.php", form1);
			StartCoroutine (takeScoreFunc (w1));

			WWWForm formQ = new WWWForm ();
			formQ.AddField ("username", username);
			WWW wQ = new WWW ("http://www.heaven.pmg-blg.com/takeQStage.php", formQ);
			StartCoroutine (takeQStage (wQ));

			WWWForm formW = new WWWForm ();
			formW.AddField ("username", username);
			WWW wW = new WWW ("http://www.heaven.pmg-blg.com/takeWStage.php", formW);
			StartCoroutine (takeWStage (wW));

			WWWForm formE = new WWWForm ();
			formE.AddField ("username", username);
			WWW wE = new WWW ("http://www.heaven.pmg-blg.com/takeEStage.php", formE);
			StartCoroutine (takeEStage (wE));

			WWWForm formR = new WWWForm ();
			formR.AddField ("username", username);
			WWW wR = new WWW ("http://www.heaven.pmg-blg.com/takeRStage.php", formR);
			StartCoroutine (takeRStage (wR));

			WWWForm formV = new WWWForm ();
			formV.AddField ("username", username);
			WWW wV = new WWW ("http://www.heaven.pmg-blg.com/takeValor.php", formV);
			StartCoroutine (takeValor (wV));
				}
	}

	IEnumerator takeScoreFunc(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			//Debug.Log(w.text);
			PlayerPrefs.SetInt("High Score", int.Parse(w.text));
		}
	}

	IEnumerator takeQStage(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(string.Format("text - {0}",w.text));
			PlayerPrefs.SetFloat("SpeedMultiplier", 5 - int.Parse(w.text));
		}
	}

	IEnumerator takeWStage(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(string.Format("text - {0}",w.text));
			PlayerPrefs.SetFloat("wCooldownModifier", 5 - int.Parse(w.text));
		}
	}

	IEnumerator takeEStage(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(string.Format("text - {0}",w.text));
			PlayerPrefs.SetFloat("eDurationModifier", 5 - int.Parse(w.text));
		}
	}

	IEnumerator takeRStage(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(string.Format("text - {0}",w.text));
			PlayerPrefs.SetFloat("rCooldownModifier", 5 - int.Parse(w.text));
		}
	}

	IEnumerator takeValor(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(string.Format("valor - {0}",w.text));
			PlayerPrefs.SetInt("Valor", int.Parse(w.text));
		}
	}

	IEnumerator loginFunc(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			if(w.text == "login-SUCCESS")
			{
				panel.SetActive(true);
				annotation.text = "Successfully logged in! Please wait...";
				PlayerPrefs.SetString("Username",username);

				Application.LoadLevel(1);
			}
			else
			{
				panel.SetActive(true);
				annotation.text = w.text;
			}
		}
	}

}
