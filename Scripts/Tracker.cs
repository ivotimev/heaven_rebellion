using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y, player.transform.position.z);
		transform.rotation = player.transform.rotation;
	
	}
}
