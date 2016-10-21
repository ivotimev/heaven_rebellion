using UnityEngine;
using System.Collections;

public class HarpyMovement : MonoBehaviour {

	private Transform harpyPos;
	Vector3 startPostition;
	Vector3 endPosition;
	float harpySpeed = 1f;
	float timeStamp;
	public float speed = 0.5f;
	public float curveDepth = -16f;
	// Use this for initialization
	void Start() {
		harpyPos = GetComponent<Transform> ();
		startPostition = harpyPos.position;
		endPosition = new Vector3 (harpyPos.position.x - 40f, -2*harpyPos.position.y/3, harpyPos.position.z);
		timeStamp = Time.time;
	}
	void Update () {
		MoveObject( (Time.time - timeStamp)/speed);
	}
	
	// Update is called once per frame
	void MoveObject(float fFraction)
	{
		Vector3 v3Delta = endPosition - startPostition;
		Vector3 v3Pos = startPostition;
		v3Pos.x += v3Delta.x * fFraction;
		v3Pos.y += v3Delta.y * fFraction + Mathf.Sin (fFraction * Mathf.PI) * curveDepth;
		float dx = harpyPos.position.x - v3Pos.x;
		float dy = harpyPos.position.y - v3Pos.y;
		float radians = Mathf.Atan2 (dy, dx);
		float rotateZ = radians * 180 / Mathf.PI - 270;
		harpyPos.eulerAngles = new Vector3 (harpyPos.rotation.x, harpyPos.rotation.y, rotateZ);
		harpyPos.position = v3Pos;
	}
}
