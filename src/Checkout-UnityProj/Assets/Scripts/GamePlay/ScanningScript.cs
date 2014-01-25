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
	private MoveItem checkfor;

	void Start () {
	
		instance = this;
	}
	void Update(){
		MoveItem ScannedItem = CheckForHit();
		if(ScannedItem!=null){
			if(!ScannedItem.IsScanned)
			{
				ScannedItem.FinishScan();
				ConveyorBelt.Instance.SpawnItem();
			}
		}
	}

	public void ScanComplete(){
		Debug.Log ("BEEEP!");
	}

	MoveItem CheckForHit(){
		RaycastHit hit;
		Vector3 center = transform.position;
		if(Physics.SphereCast(center,0.5f, new Vector3(0.5f,0,0), out hit, 500, 1<<9 )){
			return hit.transform.gameObject.GetComponent<MoveItem>();
		}
		return null;
	}
}
