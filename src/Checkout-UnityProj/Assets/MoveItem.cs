using UnityEngine;
using System.Collections;

public class MoveItem : MonoBehaviour {
	private ItemState currentState;
	enum ItemState{
		OnBelt,
		BeingScanned,
		Scanned,
		End
	}

	void FinishScan(){
		currentState=ItemState.Scanned;
		ScanningScript.Instance.ScanComplete();
	}

	void OnMouseDown(){
		Hand.Instance.PickUpItem(this);

//		switch (currentState) 
//		{
//		case ItemState.OnBelt:
//				transform.position = ScanningScript.Instance.transform.position;
//				currentState=ItemState.BeingScanned;
//				Invoke("FinishScan", 0.2f);
//
//			break;
//		case ItemState.BeingScanned:
//				//Do nothing here
//			break;
//		case ItemState.Scanned:
//				transform.position = EndpointScript.Instance.transform.position;
//				currentState = ItemState.End;
//				ConveyorBelt.Instance.SpawnItem();
//			break;
//		case ItemState.End:
//			rigidbody.AddExplosionForce(1000f, transform.position+Vector3.left, 5f);
//			break;
//		default:
//			throw new System.ArgumentOutOfRangeException ();
//		}
	}

	void OnMouseUp(){
		Hand.Instance.DropItem(this);
	}
}