using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineCommands : MonoBehaviour {
	public GameObject sardine;
	public GameObject sardines;

	public void Assemble() {
		sardines.GetComponent<SardineBoidsController>().enabled = true;
	}

	public void Disperse() {
		sardines.GetComponent<SardineBoidsController>().enabled = false;
	}

	public void Go() {
		sardine.GetComponent<SardineCharacter>().forwardSpeed = 3;
	}

	public void Stop() {
		sardine.GetComponent<SardineCharacter>().forwardSpeed = 0;
	}
}
