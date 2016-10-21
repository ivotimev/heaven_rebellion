using UnityEngine;
using System.Collections;

public class indicateClick : MonoBehaviour {

	public GameObject clickIndicator;
	public Movement movement;
	public Animator animator;

	public bool movementActive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && movement.currentSpeed == 0 && movementActive) {
						Vector3 mousePos2D = Input.mousePosition;
						mousePos2D.z = clickIndicator.transform.position.z;
						Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
						clickIndicator.transform.position = mousePos3D;
						animator.SetBool ("Stop", false);
						movement.currentSpeed = movement.speed;
						}
				}
			}				
	