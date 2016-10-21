using UnityEngine;
using System.Collections;

public class SetCursor : MonoBehaviour {

	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
	// Use this for initializ ation
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
