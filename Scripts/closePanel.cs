using UnityEngine;
using System.Collections;

public class closePanel : MonoBehaviour {

	public GameObject panel;
	// Use this for initialization
	public void closeOnClick(){
		panel.SetActive (false);
	}
}
