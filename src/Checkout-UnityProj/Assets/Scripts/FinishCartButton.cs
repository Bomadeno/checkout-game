using UnityEngine;
using System.Collections;

public class FinishCartButton : MonoBehaviour {
   
	public static FinishCartButton Instance;
	public ShopKeeperSpeach shopKeeper;
	public Material[] mats;
	private void Update()
    {
        
    }

	void Awake(){
		Instance = this;
	}
	void OnMouseDown(){
		Debug.Log("Finished customer");
		
        PoolScript.Instance.Servesed();
		DestroyBasketItems();
		shopKeeper.GetNewCustomer();
		renderer.sharedMaterial=mats[0];
	}
	void DestroyBasketItems()
	{
		GameObject tmp;
		
		for (int i=0;i<ConveyorBelt.Instance.basketItems.Count;i++)
		{
			tmp=ConveyorBelt.Instance.basketItems[i];
			Destroy(tmp);
		}
		ConveyorBelt.Instance.basket.Clear();
		ConveyorBelt.Instance.basketItems.Clear();
	}
}
