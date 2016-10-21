using UnityEngine;
using System.Collections;

public class ShowPanel : MonoBehaviour {
	public GameObject panel;

	// Use this for initialization
	public void showOnClick()
	{
		panel.SetActive (true);
	}
}
