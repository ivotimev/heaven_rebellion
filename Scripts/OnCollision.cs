using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnCollision : MonoBehaviour {

	public PlayerHealth health;
	public bool invulnerable = false;

	public GameObject exitPanel;
	public Text scoreExit;
	public Text valor;
	public Text highScore;

	public Movement movement;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy" && !invulnerable) {
			Animator animator = GetComponent<Animator>();
			animator.SetBool("Hit", true);
			if(health.health - 30 >= 0) health.health -= 30;
			else
			{
				Time.timeScale = 0;
				exitPanel.SetActive(true);
				scoreExit.text = movement.score.text;
				valor.text = Mathf.Round(int.Parse(movement.score.text)/11).ToString();
				PlayerPrefs.SetInt("Valor", PlayerPrefs.GetInt("Valor") + int.Parse(valor.text));

				WWWForm formV = new WWWForm ();
				formV.AddField ("username", PlayerPrefs.GetString("Username"));
				formV.AddField ("valor", PlayerPrefs.GetInt("Valor").ToString());
				WWW wV = new WWW ("http://www.heaven.pmg-blg.com/setValor.php" , formV);
				StartCoroutine (setValor (wV));

				highScore.text = PlayerPrefs.GetInt("High Score").ToString();
				if(PlayerPrefs.GetInt("High Score") < int.Parse(scoreExit.text))
				{
					PlayerPrefs.SetInt("High Score", int.Parse(scoreExit.text));
					WWWForm form2 = new WWWForm ();
					highScore.text = scoreExit.text;
					form2.AddField ("username", PlayerPrefs.GetString("Username"));
					form2.AddField ("Score", scoreExit.text);
					WWW w2 = new WWW ("http://heaven.pmg-blg.com/setHighScore.php", form2);
					StartCoroutine (setScoreFunc (w2));

				}
				else
				{
					highScore.text = PlayerPrefs.GetInt("High Score").ToString();
				}
			}
			}
						
		}

	IEnumerator setScoreFunc(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log(w.text);
		}
	}

	IEnumerator setValor(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			Debug.Log("smt");
			Debug.Log(w.text);
		}
	}
	
}
