using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public ShopKeeperSpeach shopKeeper;
	[HideInInspector]public List<GameObject> basket;
	[HideInInspector]public List<GameObject> basketItems;
	void Start() {
		instance = this;
		//SpawnItem();

	}

	public void SpawnItem(){
		GameObject.Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)], transform.position, transform.rotation);
	}

	public void SpawnAllBasketItems(){
		int counter=0;
		basketItems= new List<GameObject>();
		foreach(GameObject item in basket){
			basketItems.Add (GameObject.Instantiate(item, transform.position+counter*Vector3.up, transform.rotation) as GameObject);
			counter++;
		}
	}

	private void SpawnBasketItem()
	{
		if (basket.Count==0)
		{
			Debug.Log ("pay many");
			shopKeeper.GetNewCustomer();
		}else{
			GameObject.Instantiate(basket[0], transform.position, transform.rotation);
			basket.RemoveAt(0);
		}
	}
}
