using UnityEngine;
using System.Collections;

public class MoveItem : MonoBehaviour {

    public TalkTree talkTree;
    public float weight;

	private bool isScanned;
	public bool IsScanned{
		get{return isScanned;}}

	private ItemState currentState;
	enum ItemState{
		OnBelt,
		BeingScanned,
		Scanned,
		End
	}

	void Update(){

	}
	public void FinishScan(){
		isScanned= true;
		currentState=ItemState.Scanned;
	}

	void OnMouseDown(){
		Hand.Instance.PickUpItem(this);
//		switch (currentState) 
//		{
//		case ItemState.OnBelt:
//			currentState=ItemState.BeingScanned;
//			Invoke("FinishScan", 0.2f);
//			break;
//		case ItemState.BeingScanned:
//			//Do nothing here
//			break;
//		case ItemState.Scanned:
//			currentState = ItemState.End;
//			ConveyorBelt.Instance.SpawnItem();
//			break;
//		case ItemState.End:
//			//Rigidbody.AddExplosionForce(1000f, transform.position+Vector3.left, 5f);
//			break;
//		default:
//			throw new System.ArgumentOutOfRangeException ();
//		}
	}

	void OnMouseUp(){
		Hand.Instance.DropItem(this);
	}
}
