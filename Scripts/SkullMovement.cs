using UnityEngine;
using System.Collections;

public class SkullMovement : MonoBehaviour {

	public float speed = 18;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up*Time.deltaTime*speed);
	
	}
}
