using UnityEngine;
using System.Collections;

public class ConveyorBelt : MonoBehaviour {
	
	public GameObject ItemPrefab;

	void Start() {
		SpawnItem();

	}

	void SpawnItem(){
		GameObject.Instantiate(ItemPrefab, transform.position, transform.rotation);
	}
}
