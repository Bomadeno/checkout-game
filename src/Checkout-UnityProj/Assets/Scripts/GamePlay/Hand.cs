using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
	public static Hand instance;
    public GameObject HandRange;

	public static Hand Instance {
		get {
			return instance;
		}
		set {
			instance = value;
		}
	}

	private MoveItem heldItem;

	void Start(){
		instance = this;
	}

	void Update(){
		if(heldItem == null){
            HandRange.SetActive(false);
			return;
		}
        HandRange.SetActive(true);
		RaycastHit hitInfo;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 500, 1<<10)){
			heldItem.transform.position=hitInfo.point;
		}
	}

	public void PickUpItem(MoveItem item){
		if(heldItem != null){
			return;
		}
		heldItem=item;
	}

	public void DropItem(MoveItem item){
		if(item == heldItem){
			heldItem = null;
		}
	}
}
