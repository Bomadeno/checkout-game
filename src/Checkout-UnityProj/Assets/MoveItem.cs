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
		//play beep sound
	}

	void OnMouseDown(){
		switch (currentState) 
		{
		case ItemState.OnBelt:
				transform.position = ScanningScript.Instance.transform.position;
				currentState=ItemState.BeingScanned;
				Invoke("FinishScan", 2.0f);

			break;
		case ItemState.BeingScanned:
				//Do nothing here
			break;
		case ItemState.Scanned:
				transform.position = EndpointScript.Instance.transform.position;
				currentState = ItemState.End;
			break;
		case ItemState.End:
			break;
		default:
			throw new System.ArgumentOutOfRangeException ();
		}

	
		
	}
}
