using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class trackCooldownR : MonoBehaviour {

	public ActivateWrath activateWrath;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = Mathf.Round (activateWrath.remainingCooldown - Time.time).ToString ();
	}
}
