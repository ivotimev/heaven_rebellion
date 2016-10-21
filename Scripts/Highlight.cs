using UnityEngine;
using System.Collections;

public class Highlight : MonoBehaviour {

	public Sprite highlightedButton;
	public Sprite clickedButton;
	public Sprite originalButton;
	private bool mouseExited = true;

	void OnMouseEnter()
	{
		mouseExited = false;
		GetComponent<SpriteRenderer>().sprite = highlightedButton;
	}

	void OnMouseExit()
	{
		mouseExited = true;
		GetComponent<SpriteRenderer> ().sprite = originalButton;
	}

	void OnMouseDown()
	{
		GetComponent<SpriteRenderer> ().sprite = clickedButton;
	}

	void OnMouseUp()
	{
		if (mouseExited)
						GetComponent<SpriteRenderer> ().sprite = originalButton;
		else
						GetComponent<SpriteRenderer> ().sprite = highlightedButton;
	}
}
