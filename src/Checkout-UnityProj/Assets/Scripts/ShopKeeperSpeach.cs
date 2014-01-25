using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopKeeperSpeach : MonoBehaviour {
	private Customer curCustumer;
	private List<Item> servecedItems=new List<Item>();
	private List<Talk> talkVariations=new List<Talk>();
	private string[] talkTextCached;
	void Initialization()
	{
		servecedItems.Clear();
	}
	void AddItem(Item item)
	{
		servecedItems.Add(item);
	}
	
	void GenerateTalkVariations()
	{
		List<ThemeTalk> allThemes = new List<ThemeTalk>();
		allThemes.Add (ThemeTalk.health);
		allThemes.Add (ThemeTalk.joke);
		allThemes.Add (ThemeTalk.sport);
		allThemes.Add (ThemeTalk.weather);
		allThemes.Add (ThemeTalk.politic);
		allThemes.Add (ThemeTalk.none);
		
		talkVariations.Clear();
		Talk talk;
		foreach (ThemeTalk theme in allThemes)
		{
			talk=new Talk();
			talk.themeTalk=theme;
			
			talk.text=TalkDatabase.Instance.GetText(theme);
			if (theme==ThemeTalk.joke)
			{
				float rnd= Random.Range	(0f,1f);
				if (rnd>0.8f && servecedItems.Count>0 )
				{
					int index = Random.Range(0,servecedItems.Count);
					talk.text=servecedItems[index].GetRandomeJoke();
				}
			}
			talkVariations.Add(talk);
		}
		CacheText(talkVariations);
	}
	
	void CacheText(List<Talk> talks)
	{
		talkTextCached= new string[talks.Count];
		for (int i=0; i<talks.Count; i++)
		{
			talkTextCached[i]=talks[i].text;
		}
	}
	// Use this for initialization
	void Start () {
		curCustumer=PoolScript.Instance.GetNextCustumer();
		GenerateTalkVariations();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    private int selGridInt = -1;
	private bool showGrid=false;
    void OnGUI() {
		if (showGrid)
		{
			selGridInt = GUI.SelectionGrid(new Rect(25, 25, 100, 300), selGridInt, talkTextCached, 1);
			if (selGridInt!=-1)
			{
				TalkToCustumer(selGridInt);
				showGrid=false;
				selGridInt=-1;
			}
		}else{
			if (GUI.Button(new Rect(25,25,100,30),"talk"))
				showGrid=true;
		}
    }
	
	void TalkToCustumer (int indexTalk)
	{
		PoolScript.Instance.servesing.RecieveTalk(talkVariations[indexTalk]);
	}
	
}
