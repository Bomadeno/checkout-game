using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ThemeTalk{weather, joke, politic, sport, health,none};

[System.Serializable]
public class TalkNode{
	[HideInInspector] public TalkTree myTree;
	public string text;
	public AudioClip audioText;
	public string response;
	public AudioClip audioResponse;
	public int score;
	[HideInInspector] public List<int> nextElement;
	public int previousElement;
	
	public void AddNextElement(int index)
	{
		if (!nextElement.Contains(index)) nextElement.Add(index);
	}
}

[System.Serializable]
public class TalkTree{
	public List<TalkNode> talkTree= new List<TalkNode> ();
	
	public void AddNextElementLinks ()
	{
		for (int i=0; i< talkTree.Count;i++)
		{
			if (talkTree[i].previousElement>=0)
				talkTree[talkTree[i].previousElement].AddNextElement(i);
			talkTree[i].myTree=this;
		}
	}
	
}

public class Customer : MonoBehaviour {
	
	public Texture2D faceTexture;
	public Renderer face;
	public static Transform cashPoint;
	public static Transform endCashPoint;
	private Transform myTransform;
	private Transform followTransform;
	private float timer;
	public string customerName="NoName";
	public TalkTree talkTree= new TalkTree();
	[HideInInspector]public List<MoveItem> bascket= new List<MoveItem>();
	public List<MoveItem> listItemsBascket= new List<MoveItem>();
	
	[HideInInspector]public List<TalkTree> talks = new List<TalkTree>();
	// Use this for initialization
	void Start () {
		//renderer.sharedMaterial=faceTexture;
		if (faceTexture!=null)face.material.SetTexture("_MainTex", faceTexture);
		myTransform=transform;
		timer=0;
	}
	void Update()
	{
		if (followTransform!=null)
		{
			timer+=Time.deltaTime*0.1f;
			myTransform.position = Vector3.Lerp(myTransform.position,followTransform.position,timer);
			if (timer>1f)
			{
				followTransform=null;
				timer=0;
			}
		}
	}
	public void GoToCash()
	{
		followTransform=cashPoint;
	}
	public void GoAway()
	{
		followTransform=endCashPoint;
	}

	public void Initilization()
	{
		GoToCash();
		FillBasket();
		FillTalks();
		FillNextElements();
	}
	void FillBasket()
	{
		float sumW=0;
		float[] cumArr=new float[listItemsBascket.Count+1];
		cumArr[0]=0f;
		for( int i =0; i < listItemsBascket.Count;i++)
		{
			sumW+=listItemsBascket[i].weight;
			cumArr[i+1]=sumW;
		}
		
		int itemAmount=Random.Range(1,6);
		
		for (int i=0;i<itemAmount;i++)
		{
			float itemIndex=Random.Range(0f,sumW);
			for (int j=0;j<listItemsBascket.Count;j++)
			{
				if ((cumArr[j]<=itemIndex)&&(itemIndex<cumArr[j+1])) 
				{
					bascket.Add(listItemsBascket[j]);
					break;
				}
			}
		}
		
		foreach (MoveItem item in bascket)
		{
			ConveyorBelt.Instance.basket.Add(item.gameObject);
		}
		ConveyorBelt.Instance.SpawnAllBasketItems();
	}
	void FillNextElements()
	{
		talks.Clear();
		talks.Add(talkTree);
		foreach (TalkTree tree in talks)
		{
			tree.AddNextElementLinks();
		}
		
	}
	void FillTalks()
	{
		talks.Clear();
		talks.Add(talkTree);
		foreach (MoveItem item in bascket)
		{
			talks.Add(item.talkTree);	
		}
	}
	
	bool presed=false ;
	void OnMouseUp()
	{
		if (!presed)ShopKeeperSpeach.Instance.StartTalk();
		presed=true;
	}
	

	
}
