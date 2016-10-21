using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateWrath : MonoBehaviour {

	public Text score;
	public float cooldown = 45;
	public float remainingCooldown;

	public GameObject cooldownPanel;

	void Start()
	{
		remainingCooldown = Time.time;
		cooldown = cooldown / (1f + (5f - PlayerPrefs.GetFloat ("rCooldownModifier"))*0.0675f);
	}
	// Use this for initialization
	void Update()
	{
		if (Time.time >= remainingCooldown) {
			cooldownPanel.SetActive(false);
				}
		if (Input.GetKey (KeyCode.R) && Time.time >= remainingCooldown) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			int scoreNumber = int.Parse (score.text);
			foreach (GameObject enemy in enemies) {
				Destroy(enemy);
				scoreNumber = (int)Mathf.Round(scoreNumber*1.5f);
			
			}
			score.text = scoreNumber.ToString();
			remainingCooldown = Time.time + cooldown;
			cooldownPanel.SetActive(true);
				}

		}

	}
