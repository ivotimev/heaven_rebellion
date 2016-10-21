using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moveSlider : MonoBehaviour {

	public Slider sliderS;
	public Text info;
	public string phpPath;//"http://heaven.pmg-blg.com/setQStage.php"
	public string abilityModifier;
	public int valorCost;
	public string infoFormat;
	public float percPerStage;

	// Use this for initialization

	public void onClick(){
		if (PlayerPrefs.GetInt ("Valor") >= valorCost) {
			sliderS.value -= 1;
			PlayerPrefs.SetFloat(abilityModifier, sliderS.value);
			PlayerPrefs.SetInt("Valor", PlayerPrefs.GetInt("Valor")-valorCost);

			WWWForm formV = new WWWForm ();
			formV.AddField ("username", PlayerPrefs.GetString("Username"));
			formV.AddField ("valor", PlayerPrefs.GetInt("Valor").ToString());
			WWW wV = new WWW ("http://www.heaven.pmg-blg.com/setValor.php" , formV);
			StartCoroutine (setValor (wV));

			WWWForm formQ = new WWWForm ();
			formQ.AddField ("username", PlayerPrefs.GetString("Username"));
			formQ.AddField ("stage", (5 - sliderS.value).ToString());
			WWW w2 = new WWW (phpPath , formQ);
			StartCoroutine (setQStage (w2));
			}
		}
	void Start (){
		sliderS.value = PlayerPrefs.GetFloat (abilityModifier);
		}
	void Update(){
		info.text = string.Format ("{0} \n (+{1}%)",infoFormat, (5 - sliderS.value)*percPerStage);
	}

	IEnumerator setQStage(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(PlayerPrefs.GetFloat (abilityModifier));
			Debug.Log(w.text);
		}
	}

	IEnumerator setValor(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(w.text);
		}
	}
}
