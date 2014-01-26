using UnityEngine;
using System.Collections;

public class FinishCartButton : MonoBehaviour {
   
	public ShopKeeperSpeach shopKeeper;

	private void Update()
    {
        
    }

	void OnMouseDown(){
		Debug.Log("Finished customer");
        PoolScript.Instance.Servesed();
		DestroyBasketItems();
		shopKeeper.GetNewCustomer();
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
