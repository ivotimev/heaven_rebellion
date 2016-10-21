using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	public ActivateBulwark activateBulwark;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = (Mathf.Round(activateBulwark.remainingCooldown - Time.time)).ToString();
	}
}
