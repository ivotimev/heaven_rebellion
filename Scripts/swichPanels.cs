using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class swichPanels : MonoBehaviour {

	public GameObject sliders;
	public GameObject highScores;
	// Use this for initialization
	public void onClick()
	{
		highScores.SetActive (true);
		sliders.SetActive (false);
	}
}
