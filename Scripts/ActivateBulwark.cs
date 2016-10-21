using UnityEngine;
using System.Collections;

public class ActivateBulwark : MonoBehaviour {

	public float cooldown = 5f;
	public float remainingCooldown;
	private bool bulwarkActive = false;
	private bool wasActive = false;

	public GameObject panel;

	public GameObject shield;
	public GameObject indicator;

	public float duration = 2f;
	private float remainingDuration;

	public Transform click;

	public GameObject player;
	private OnCollision onCollision;
	// Use this for initialization
	void Start () {
		remainingCooldown = Time.time;
		remainingDuration = Time.time;
		float durationModifier = 1 + (5 - PlayerPrefs.GetFloat ("eDurationModifier"))*0.0875f;
		duration = duration * durationModifier;
		onCollision = player.GetComponent<OnCollision> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= remainingCooldown)
						panel.SetActive (false);
		if (Input.GetKey (KeyCode.E) && Time.time >= remainingCooldown) {
			bulwarkActive = true;
			indicator.SetActive(true);
				}
		if (Input.GetKey (KeyCode.Mouse0) && bulwarkActive == true) {
			shield.SetActive(true);
			onCollision.invulnerable = true;
			Vector3 mousePos2D = Input.mousePosition;
			mousePos2D.z = player.transform.position.z;
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
			click.position = mousePos3D;
			remainingDuration = Time.time + duration;
			wasActive = true;
			bulwarkActive = false;
				}
		if (wasActive == true && Time.time >= remainingDuration) {
			wasActive = false;
			shield.SetActive(false);
			indicator.SetActive(false);
			onCollision.invulnerable = false;
			remainingCooldown = cooldown + Time.time;
			panel.SetActive(true);
				}
	}
}
