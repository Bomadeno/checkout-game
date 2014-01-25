using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ThemeTalk{weather, joke, politic, sport, health,none};

[System.Serializable]
public class Talk{
	public ThemeTalk themeTalk;
	[HideInInspector] public int level;
	[HideInInspector]public string text;
}
public class Customer : MonoBehaviour {
	
	public List<Talk> talks= new List<Talk>();
	public List<Item> bascket= new List<Item>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void RecieveTalk (Talk talk)
	{
		bool isgood=false;
		foreach (Talk myTalk in talks)
		{
			if (myTalk.themeTalk==talk.themeTalk)
			{
				isgood=true;
				break;
			}
		}
		ReputationAction(isgood);
		
	}
	void ReputationAction(bool isPositive)
	{
		string message;
		message= isPositive? "u have guessed right theme ":" u lose talk ";
		Debug.Log(message);
	}
}
