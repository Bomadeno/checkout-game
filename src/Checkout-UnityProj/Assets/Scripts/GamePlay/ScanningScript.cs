using UnityEngine;
using System.Collections;

public class ScanningScript : MonoBehaviour {
	private static ScanningScript instance;
	public static ScanningScript Instance {
		get {
			return instance;
		}
		set {
			instance = value;
		}
	}

	void Start () {
	
		instance = this;
	}

	public void ScanComplete(){
		Debug.Log ("BEEEP!");
	}
}
