using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PopUpRegistrationForm : MonoBehaviour {

	public GameObject registrationForm;
	public GameObject registrationButton;
	// Use this for initialization
	public void PopUpForm(){
		registrationForm.SetActive(true);
		registrationButton.SetActive (false);
	}

}
