using UnityEngine;
using System.Collections;

public class Player : Characters {

	private int playerLevel = 1;
	private float levelExp = 0;
	private float levelUpExp = 1;
	private MyGUI statsGui;
	private float multiplier = 1;
	private float baseMultiplier = 1.5f;

	public void GainExperience(float expGained){
		levelExp += (expGained / multiplier);
		statsGui.updateKills (StaticVars.killCount);
		if (levelExp >= levelUpExp) {
			EventManager.OnLevelUp();
		}
		statsGui.updateXP (levelExp);
	}

	public override void takeDamage(float damageAmount){
		health -= damageAmount;
		statsGui.updateHP (health);
		if (health <= 0) {
			health = 0;
			Death();
		}
	}
	
	void LevelUp ()
	{
		levelExp -= levelUpExp;
		playerLevel++;
		statsGui.updateLevel (playerLevel);
		StaticVars.upgradePointsAvailable += 3;
		multiplier = playerLevel * baseMultiplier;
	}

	void ResetHealth ()
	{
		health = 1;
		statsGui.updateHP (health);
	}

	public override void Death ()
	{
		StaticVars.playerDead = true;
	}

	void Start () {
		statsGui = GameObject.FindGameObjectWithTag ("GUI").GetComponent<MyGUI> ();
		EventManager.LeveledUp += LevelUp;
		EventManager.LeveledUp += ResetHealth;
		statsGui.updateXP (levelExp);
		StaticVars.staticPlayerLevel = playerLevel;
	}
}
