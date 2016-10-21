using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SsetActive : MonoBehaviour {

	public GameObject valorPanel;
	public Text valorText;
	public GameObject scoresPanel;
	public Text scoresText;
	public Text highScoresText;
	// Use this for initialization
	public void setActive()
	{
		Debug.Log ("ColorChanged");
		Image valorPanelImage = valorPanel.GetComponent<Image> ();
		Color imageCol = valorPanelImage.color;
		imageCol.a = 0.45f;
		valorPanelImage.color = imageCol;
		Image scorePanelImage = scoresPanel.GetComponent<Image> ();
		imageCol.a = 0.85f;
		scorePanelImage.color = imageCol;
		imageCol = scoresText.color;
		imageCol.a = 255;
		scoresText.color = imageCol;
		imageCol.a = 0.45f;
		valorText.color = imageCol;

		WWWForm form = new WWWForm ();
		form.AddField ("Something", "01");
		WWW w = new WWW ("http://heaven.pmg-blg.com/getHighScores.php", form);
		StartCoroutine (displayHighScores (w));
	}

	IEnumerator displayHighScores(WWW w)
	{
		yield return w;
		Debug.Log (w.text);
		if (w.error == null) 
		{
			Debug.Log("smt");
			highScoresText.text = w.text;
		}
	}

}
