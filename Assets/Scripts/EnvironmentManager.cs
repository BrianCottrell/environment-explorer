/*
Code by Thomas Suarez "tomthecarrot"
HoloHacks 2017
*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnvironmentManager : MonoBehaviour {

	// Singleton reference
	public static EnvironmentManager instance;

	// Environment Objects
	public GameObject[] environments;
	public GameObject defaultEnvironment;

	void Start() {
		// Set singleton reference
		EnvironmentManager.instance = this;

		// Switch environment to default (set in Unity Editor's inspector)
		SwitchEnvironment(defaultEnvironment);

		// Add voice commands for all environment names
		SetVoiceCommands();
	}

	// Switches to a new environment (empty parent gameobject)
	public void SwitchEnvironment(GameObject newEnvironment) {
		// Disable all environments
		foreach (GameObject environment in environments) {
			environment.SetActive(false);
		}

		// Enable new environment
		newEnvironment.SetActive(true);
	}

	private void SetVoiceCommands() {
		// Add a voice command for each environment name
		foreach (GameObject environment in environments) {
			string name = environment.name;
			string command = "take me to " + name;
			VoiceManager.instance.AddKeyword(command, () => SwitchEnvironment(environment));
		}

		// Make and start the speech recognizer
		VoiceManager.instance.MakeRecognizer();
	}

}
