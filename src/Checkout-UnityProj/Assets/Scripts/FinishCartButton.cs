using UnityEngine;
using System.Collections;

public class FinishCartButton : MonoBehaviour {
    private void Update()
    {
        
    }

	void OnMouseDown(){
		Debug.Log("Finished customer");
        PoolScript.Instance.Servesed();
	}
}
