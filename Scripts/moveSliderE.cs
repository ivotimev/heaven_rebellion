using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moveSliderE : MonoBehaviour {
	
	public Slider sliderS;
	public Text info;
	// Use this for initialization
	
	public void onClick(){
		if (PlayerPrefs.GetInt ("Valor") >= 95) {
			sliderS.value -= 0.4f;
			PlayerPrefs.SetInt("Valor", PlayerPrefs.GetInt("Valor")-95);
		}
	}
	void Start (){
		sliderS.value = PlayerPrefs.GetFloat ("eDurationModifier");
	}
	void Update(){
		PlayerPrefs.SetFloat ("eDurationModifier", sliderS.value);
		sliderS.value = PlayerPrefs.GetFloat ("eDurationModifier");
		info.text = string.Format ("Holy Bulwark Duration \n (+{0}%)", (2f - sliderS.value) * 100);
	}
}

