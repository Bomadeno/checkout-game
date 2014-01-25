using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Item : MonoBehaviour {
	
	public List<string> jokes= new List<string>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string GetRandomeJoke()
	{
		if (jokes.Count==0) return string.Empty;
		int index=Random.Range(0, jokes.Count);
		return jokes[index];		
	}
}
