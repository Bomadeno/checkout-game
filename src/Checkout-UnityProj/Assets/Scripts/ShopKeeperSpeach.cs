using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopKeeperSpeach : MonoBehaviour {
	
	private static ShopKeeperSpeach instance;
	public static ShopKeeperSpeach Instance { get { return instance;}}

	
	public  Transform cashPoint;
	public  Transform endCashPoint;
	
	public AudioSource mySource;
	private Customer curCustumer;
	private string[] talkTextCached;

	private List<TalkNode> nodes= new List<TalkNode>();
	private TalkNode activeNode;
	private bool showTalkButtons=false ;
	void GenerateTalkVariations()
	{
		
		if (nodes.Count==0)
		{
			nodes=GetAllNodes(curCustumer.talks);
		}else{
			nodes=GetAllNodes(activeNode.myTree,activeNode.nextElement);
		}
		CacheText(nodes);
	}
	
	List<TalkNode> GetAllNodes(List<TalkTree> trees)
	{
		List<TalkNode> newNodes= new List<TalkNode>();
		foreach (TalkTree tree in trees)
		{
			newNodes.AddRange( GetAllNodes(tree,-1));
		}
		return newNodes;
	}
	
	List<TalkNode> GetAllNodes(TalkTree tree, int previousElement)
	{
		List<TalkNode> newNodes= new List<TalkNode>();
		foreach (TalkNode node in tree.talkTree)
		{
			if (node.previousElement==previousElement)
			{
				newNodes.Add(node);
			}
		}
		return newNodes;
	}
	List<TalkNode> GetAllNodes(TalkTree tree, List<int> elements)
	{
		if (elements.Count==0)
		{
			showGrid=false;
			Debug.Log("stoped talking");
		}
		List<TalkNode> newNodes= new List<TalkNode>();
		
		foreach (int element in elements)
		{
			newNodes.Add(tree.talkTree[element]);
		}
		return newNodes;
	}
	
	void CacheText(List<TalkNode> listNodes)
	{
		talkTextCached= new string[listNodes.Count];
		for (int i=0; i<listNodes.Count; i++)
		{
			talkTextCached[i]=listNodes[i].text;
		}
	}
	// Use this for initialization
	void Awake()
	{
		instance=this;
		
		Customer.cashPoint=cashPoint;
		Customer.endCashPoint=endCashPoint;
	}
	void Start () {
		GetNewCustomer();
		
	}
	public void GetNewCustomer()
	{
		nodes=new List<TalkNode>();
		if (curCustumer!=null) {
			curCustumer.GoAway();
			Score.Instance.LogCustomerExperience(curCustumer);
		}
		curCustumer=PoolScript.Instance.GetNextCustumer();
		if (curCustumer!=null)
		{
			curCustumer.Initilization();
			showTalkButtons=true;
			showGrid=false;
		}else{
			Debug.Log ("quere is finished");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
    private int selGridInt = -1;
	private bool showGrid=false;
    void OnGUI() {
		if (!showTalkButtons) return;
		if (showGrid)
		{
			selGridInt = GUI.SelectionGrid(new Rect(25, 25, 300, 300), selGridInt, talkTextCached, 1);
			if (selGridInt!=-1)
			{
				StartCoroutine(TalkToCustumer(selGridInt));
				selGridInt=-1;
			}
		}else{
			/*
			if (GUI.Button(new Rect(25,25,100,30),"talk")){
				GenerateTalkVariations();
				showGrid=true;
			}*/
		}
    }
	public void StartTalk()
	{
		GenerateTalkVariations();
		showGrid=true;
	}
	IEnumerator TalkToCustumer (int indexTalk)
	{
		showTalkButtons=false;
		activeNode=nodes[indexTalk];
		Debug.Log("Shopkeeper: "+activeNode.text);
		mySource.clip=activeNode.audioText;
		mySource.Play();
		if (mySource.clip!=null) yield return new WaitForSeconds (activeNode.audioText.length);
		Debug.Log("Customer: "+activeNode.response);
		mySource.clip=activeNode.audioResponse;
		mySource.Play();		
		if (mySource.clip!=null) yield return new WaitForSeconds (activeNode.audioResponse.length);
		
		showTalkButtons=true;
		GenerateTalkVariations();
	}
	
	
	
}
