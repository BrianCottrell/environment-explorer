using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
	Rigidbody rigidbody;

	void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody> ();
	}

	public void toggleFalling() {
		rigidbody.useGravity = !rigidbody.useGravity;
	}
}
