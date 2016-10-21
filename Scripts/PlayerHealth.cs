using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100;
	public float maxHealth = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Image healhBar = GetComponent<Image> ();
		healhBar.fillAmount = health / maxHealth;
	}
}
