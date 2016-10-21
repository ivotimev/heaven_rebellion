using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hidePannel : MonoBehaviour {

	public GameObject panelToHide;
	// Use this for initialization
	public void hide()
	{
		panelToHide.SetActive (false);
	}
}
