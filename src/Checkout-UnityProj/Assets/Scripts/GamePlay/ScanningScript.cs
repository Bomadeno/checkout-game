using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
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
                ScanComplete();
				FinishCartButton.Instance.renderer.sharedMaterial=FinishCartButton.Instance.mats[1];
				//ConveyorBelt.Instance.SpawnItem();
				//ConveyorBelt.Instance.SpawnBasketItem();
			}
		}
	}

	public void ScanComplete(){
		Debug.Log ("Item scanned!");
        audio.Play();

	}

	MoveItem CheckForHit(){
		RaycastHit hit;
		Vector3 center = transform.position;
		if(Physics.SphereCast(center,0.5f, transform.up, out hit, 500, 1<<9 )){
			return hit.transform.gameObject.GetComponent<MoveItem>();
		}
		return null;
	}
}
