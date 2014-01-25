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
	
	public TalkTree talkTree= new TalkTree();
	public List<Item> bascket= new List<Item>();
	
	[HideInInspector]public List<TalkTree> talks = new List<TalkTree>();
	// Use this for initialization
	void Start () {
		FillTalks();
		FillNextElements();
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
		foreach (Item item in bascket)
		{
			talks.Add(item.talkTree);	
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
