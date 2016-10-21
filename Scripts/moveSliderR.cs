using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moveSliderR : MonoBehaviour {

	public Slider sliderW;
	public Text info;
	// Use this for initialization
	
	public void onClick(){
		if (PlayerPrefs.GetInt ("Valor") >= 200) {
			sliderW.value -= 0.0675f;
			PlayerPrefs.SetInt("Valor", PlayerPrefs.GetInt("Valor")-200);
		}
	}
	void Start (){
		sliderW.value = PlayerPrefs.GetFloat ("rCooldownModifier");
	}
	void Update(){
		PlayerPrefs.SetFloat ("rCooldownModifier", sliderW.value);
		sliderW.value = PlayerPrefs.GetFloat ("rCooldownModifier");
		info.text = string.Format ("Angelic Wrath Cooldown \n (-{0}%)", (0.3375f - sliderW.value) * 100);
	}
}
