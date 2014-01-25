using UnityEngine;
using System.Collections;

public class EndpointScript : MonoBehaviour {

	private static GameObject instance;

	public static GameObject Instance {
		get {
			return instance;
		}
		set {
			instance = value;
		}
	}

	void Start () {
		instance = gameObject;
	}
}
