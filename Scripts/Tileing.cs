using UnityEngine;
using System.Collections;

public class Tileing : MonoBehaviour {

	public Transform character;
	public Transform clouds1;
	public Transform clouds2;
	public byte frontCloud = 2;
	// Use this for initialization
	void Start () {
		//;
	}
	
	// Update is called once per frame
	void Update () {
		if (frontCloud == 2 && character.position.x >= clouds2.position.x) {
			frontCloud = 1;
			clouds1.position = new Vector3 (clouds1.position.x + 2*clouds1.renderer.bounds.size.x - 0.1f, clouds1.position.y, clouds1.position.z);
				}
		if (frontCloud == 1 && character.position.x >= clouds1.position.x) {
			frontCloud = 2;
			clouds2.position = new Vector3 (clouds2.position.x + 2*clouds2.renderer.bounds.size.x - 0.1f, clouds2.position.y, clouds2.position.z);
		}
	}
}
