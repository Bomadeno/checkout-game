using UnityEngine;
using System.Collections;

public class Rollbar : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround(transform.up, -2*Time.fixedDeltaTime);;

		//rigidbody.AddTorque(transform.up *-0.03f);
	}
}
