using UnityEngine;
using System.Collections;

public class PoolScript : MonoBehaviour {
	
	private static PoolScript instance;
	public static PoolScript Instance { get { return instance;}}
	void Awake()
	{
		instance=this;
	}
	
	
	public Transform query;
	public Transform servesed;
	[HideInInspector]public Customer servesing;
	// Use this for initialization
	void Start () {
	
	}
	
	public Customer GetNextCustumer()
	{
		if (query.childCount==0) return null;
		servesing=query.GetChild(0).GetComponent<Customer>();
		return servesing;
	}
	public void Servesed()
	{
		servesing.transform.parent=servesed;
	}
	//Update is called once per frame
	void Update () {
	
	}
}
