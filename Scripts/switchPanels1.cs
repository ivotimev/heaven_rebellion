using UnityEngine;
using System.Collections;

public class switchPanels1 : MonoBehaviour {

	public GameObject sliders;
	public GameObject highScores;
	// Use this for initialization
	public void onClick()
	{
		highScores.SetActive (false);
		sliders.SetActive (true);
	}
}
