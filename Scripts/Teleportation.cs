using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Teleportation : MonoBehaviour {

	public GameObject player;
	public GameObject click;
	public indicateClick clickIndication;

	public GameObject cooldownPanel;

	private bool telpActive = false;
	private bool teleported = false;

	public float teleportDiatance = 15;

	private Animator animator;

	private float timeStamp;

	public Texture2D cursorTextureTeleport;
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	public float cooldown = 10;
	public float remainingCooldown;


	// Use this for initialization
	void Start () {
		cooldown = cooldown / (1 + (5f - PlayerPrefs.GetFloat ("wCooldownModifier"))*0.075f);
		animator = player.GetComponent<Animator>();
		remainingCooldown = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (remainingCooldown < Time.time)
						cooldownPanel.SetActive (false);
		if (Input.GetKey(KeyCode.W) && Time.time >= remainingCooldown) {
			telpActive = true;
			Cursor.SetCursor(cursorTextureTeleport, hotSpot, cursorMode);
				}
		if (Input.GetKey(KeyCode.Mouse0 )&& telpActive == true) {
			animator.SetBool("Teleport",true);
			telpActive = false;
			teleported = true;
			timeStamp = Time.time + 0.15f;
			clickIndication.movementActive = false;
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			remainingCooldown = Time.time + cooldown;
			cooldownPanel.SetActive(true);
				}
		if (teleported == true && Time.time >= timeStamp) {
			Vector3 mousePos2D = Input.mousePosition;
			mousePos2D.z = player.transform.position.z;
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
			Vector3 movement = player.transform.position - mousePos3D;
			player.transform.Translate(-movement.normalized*teleportDiatance, Space.World);
			teleported = false;
			click.transform.position = player.transform.position;
			animator.SetBool("Teleport",false);
			clickIndication.movementActive = true;
		}
						
	}
}
