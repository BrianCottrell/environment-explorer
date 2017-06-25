using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour {

	public GameObject[] environments;
	public GameObject defaultEnvironment;

	// Use this for initialization
	void Start () {
		SwitchEnvironment (defaultEnvironment);
	}

	public void DisableAll() {
		// Disable all envrionments
		foreach (GameObject environment in environments) {
			environment.SetActive(false);
		}
	}

	public void SwitchEnvironment(GameObject environment) {
		DisableAll();
		environment.SetActive(true);
	}

}
