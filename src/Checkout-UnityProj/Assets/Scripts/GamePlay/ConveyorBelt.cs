using UnityEngine;
using System.Collections;

public class ConveyorBelt : MonoBehaviour {
	private static ConveyorBelt instance;

	public static ConveyorBelt Instance {
		get {
			return instance;
		}
		set {
			instance = value;
		}
	}

	public GameObject[] ItemPrefabs;

	void Start() {
		instance = this;
		SpawnItem();

	}

	public void SpawnItem(){
		GameObject.Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)], transform.position, transform.rotation);
	}
}
