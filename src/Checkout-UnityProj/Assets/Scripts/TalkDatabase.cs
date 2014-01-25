using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TalkDatabase : MonoBehaviour {
	
	public List<string> weather;
	public List<string> joke;
	public List<string> politic;
	public List<string> sport;
	public List<string> health;
	public List<string> randomField;
	
	private static TalkDatabase instance;
	public static TalkDatabase Instance { get { return instance;}}
	void Awake()
	{
		instance=this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string GetText( ThemeTalk themeTalk)
	{
		List<string> strings= new List<string>();
		switch (themeTalk){
		case ThemeTalk.health:
			strings=health;
			break;
		case ThemeTalk.joke:
			strings=joke;
			break;
		case ThemeTalk.none:
			strings=randomField;
			break;
		case ThemeTalk.politic:
			strings=politic;
			break;
		case ThemeTalk.sport:
			strings=sport;
			break;	
		case ThemeTalk.weather:
			strings=weather;
			break;			
		}
		
		int index=Random.Range(0, strings.Count);
		
		return strings[index];
	}
}
