using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownW : MonoBehaviour {

	public Teleportation teleportation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = Mathf.Round (teleportation.remainingCooldown - Time.time).ToString ();
	
	}
}
