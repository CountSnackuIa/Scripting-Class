using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	public GameObject upgradeMenu;
	public int pistolNeededUpgradePoints;
	public int shotgunNeededUpgradePoints;
	public int rifleNeededUpgradePoints;
	public int armorNeededUpgradePoints;
	public int pistolUpgradeCounter;
	public int shotgunUpgradeCounter;
	public int rifleUpgradeCounter;
	public int armorUpgradeCounter;
	public Text pistolText;
	public Text pistolNext;
	public Text shotgunText;
	public Text shotgunNext;
	public Text rifleText;
	public Text rifleNext;
	public Text armorText;
	public Text armorNext;
	public Text availableText;
	private string defaultDamageText;
	private string defaultNextLevelText;
	private string defaultArmorText;
	private string defaultAvailableText;
	private int counterLimit = 3;
	private float multiplierIncrease = .2f;

	void UpdateText(float _multiplier, int _neededPoints, ref Text _text, ref Text _next){
		_text.text = defaultDamageText + _multiplier;
		_next.text = defaultNextLevelText + _neededPoints;
	}
	
	bool UpgradeCheck(int pointsToUpgrade){
		if(StaticVars.upgradePointsAvailable < pointsToUpgrade)
			return false;
		else
			return true;
	}

	int UpdateCounter(int upgradeCounter, ref int neededPoints)
	{
		upgradeCounter++;
		if (upgradeCounter == counterLimit) 
		{
			upgradeCounter = 0;
			neededPoints++;
		}
		return upgradeCounter;
	}

	public void UpdatePistolMultiplier(){
		if (UpgradeCheck (pistolNeededUpgradePoints)) {
			StaticVars.pistolMultiplier += multiplierIncrease;
			StaticVars.upgradePointsAvailable -= pistolNeededUpgradePoints;
			UpdateText (StaticVars.pistolMultiplier, pistolNeededUpgradePoints, ref pistolText, ref pistolNext);
			pistolUpgradeCounter = UpdateCounter (pistolUpgradeCounter, ref pistolNeededUpgradePoints);
		}
	}

	public void UpdateShotgunMultiplier(){
		if (UpgradeCheck (shotgunNeededUpgradePoints)) {
			StaticVars.shotgunMultiplier += multiplierIncrease;
			StaticVars.upgradePointsAvailable -= shotgunNeededUpgradePoints;
			UpdateText (StaticVars.shotgunMultiplier, shotgunNeededUpgradePoints, ref shotgunText, ref shotgunNext);
			shotgunUpgradeCounter = UpdateCounter (shotgunUpgradeCounter, ref shotgunNeededUpgradePoints);
		}
	}

	public void UpdateRifleMultiplier(){
		if (UpgradeCheck (rifleNeededUpgradePoints)) {
			StaticVars.rifleMultiplier += multiplierIncrease;
			StaticVars.upgradePointsAvailable -= rifleNeededUpgradePoints;
			UpdateText (StaticVars.rifleMultiplier, rifleNeededUpgradePoints, ref rifleText, ref rifleNext);
			rifleUpgradeCounter = UpdateCounter (rifleUpgradeCounter, ref rifleNeededUpgradePoints);
		}
	}

	public void UpdateArmorModifier(){
		if (UpgradeCheck (armorNeededUpgradePoints)) {
			pistolUpgradeCounter++;
			StaticVars.armorModifier += .02f;
			StaticVars.upgradePointsAvailable -= armorNeededUpgradePoints;
			armorText.text = defaultArmorText + StaticVars.armorModifier;
			armorNext.text = defaultNextLevelText + armorNeededUpgradePoints;
			if (armorUpgradeCounter == 5){
				armorUpgradeCounter = 0;
				armorNeededUpgradePoints++;
			}
		}
	}

	public void Back(){
		upgradeMenu.SetActive (false);
		Pause.BackFromUpgrade ();
	}

	void Update () {
		if (StaticVars.upgradePointsAvailable != 0) 
			availableText.text = defaultAvailableText + StaticVars.upgradePointsAvailable;
		else		
			availableText.text = defaultAvailableText + 0;
	}

	void Start () {
		defaultDamageText = "Damage: x";
		defaultNextLevelText = "Next Level: ";
		defaultArmorText = "Armor: ";
		defaultAvailableText = "Available Pts: ";
		pistolText.text = defaultDamageText + 1;
		pistolNext.text = defaultNextLevelText + 1;
		shotgunText.text = defaultDamageText + 1;
		shotgunNext.text = defaultNextLevelText + 1;;
		rifleText.text = defaultDamageText + 1;
		rifleNext.text = defaultNextLevelText + 1;;
		armorText.text = defaultArmorText + 0;
		armorNext.text = defaultNextLevelText + 1;;
		availableText.text = defaultAvailableText + 0;
		StaticVars.upgradePointsAvailable = 0;
		StaticVars.pistolMultiplier = 1;
		StaticVars.shotgunMultiplier = 1;
		StaticVars.rifleMultiplier = 1;
		StaticVars.armorModifier = 0;
		pistolNeededUpgradePoints = 1;
		shotgunNeededUpgradePoints = 1;
		rifleNeededUpgradePoints = 1;
		armorNeededUpgradePoints = 1;
		upgradeMenu = GameObject.FindGameObjectWithTag ("UpgradeMenu");
	}
}

