using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void LevelingUp();
	public static event LevelingUp LeveledUp;

	static public void OnLevelUp()
	{
		if(EventManager.LeveledUp != null)
			EventManager.LeveledUp();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
