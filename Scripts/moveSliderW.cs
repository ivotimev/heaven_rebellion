using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moveSliderW : MonoBehaviour {

	public Slider sliderW;
	public Text info;
	// Use this for initialization
	
	public void onClick(){
		if (PlayerPrefs.GetInt ("Valor") >= 125) {
			sliderW.value -= 0.075f;
			PlayerPrefs.SetInt("Valor", PlayerPrefs.GetInt("Valor")-125);
		}
	}
	void Start (){
		sliderW.value = PlayerPrefs.GetFloat ("wCooldownModifier");
	}
	void Update(){
		PlayerPrefs.SetFloat ("wCooldownModifier", sliderW.value);
		sliderW.value = PlayerPrefs.GetFloat ("wCooldownModifier");
		info.text = string.Format ("Mystical Dispersion Cooldown \n (-{0}%)", (0.375f - sliderW.value) * 100);
	}
}
