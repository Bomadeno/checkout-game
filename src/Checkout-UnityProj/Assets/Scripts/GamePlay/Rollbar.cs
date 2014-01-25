using UnityEngine;
using System.Collections;

public class Rollbar : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {

		rigidbody.AddTorque(transform.up *-3);
	}
}
