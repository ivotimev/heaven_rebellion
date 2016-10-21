using UnityEngine;
using System.Collections;

public class CloseRegistrationForm : MonoBehaviour {

	public GameObject regForm;
	public GameObject registrationButton;

	public void closeForm()
	{
		regForm.SetActive (false);
		registrationButton.SetActive (true);
	}
}
