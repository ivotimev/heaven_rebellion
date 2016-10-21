using UnityEngine;
using System.Collections;

public class moveWithMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform positionT = GetComponent<Transform> ();
		Vector3 mouse = Input.mousePosition;
		mouse.z = 30;
		mouse = Camera.main.ScreenToWorldPoint (mouse);
		positionT.position = mouse;
	
	}
}
