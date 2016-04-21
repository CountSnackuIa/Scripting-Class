using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EnemyWeapon : Weapon {

	private float distanceFromPlayer; //Not in the Player Weapon

	public override void Contact(RaycastHit _hit)
	{
		if (_hit.collider.GetComponent<Player>())
			_hit.collider.GetComponent<Player>().takeDamage(damage*StaticVars.pistolMultiplier);
	}

	void FixedUpdate () { //Not in Player Script
		Shoot ();
		roundsPerMinute = Random.Range (20, 30); 
		fireRateSpacing = 60 / roundsPerMinute;
	}
}
