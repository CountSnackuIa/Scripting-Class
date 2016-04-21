using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticVars : MonoBehaviour {

	public static Vector3 playerPosition;
	public static Vector3 playerLookPosition;
	public static bool playerDead;
	public static int killCount;
	public static float playerLevelMultiplier;
	public static int staticPlayerLevel;
	public static int upgradePointsAvailable;
	public static float pistolMultiplier;
	public static float shotgunMultiplier;
	public static float rifleMultiplier;
	public static float armorModifier;
	public static bool isPaused;
	public static bool titleMenuActive;
	public static bool gameIsActive;


	void Start () {
		killCount = 0;
		isPaused = false;
		playerDead = false;
		titleMenuActive = true;
	}
}
