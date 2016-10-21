using UnityEngine;
using System.Collections;

public class SetSortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().sortingLayerName = "Particles";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
