using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerWeapon : Weapon {

	public enum GunType {
		Pistol,
		Shotgun,
		Rifle
	}
	public GunType fireRate;

	public override void Contact(RaycastHit _hit)
	{
		if (_hit.collider.GetComponent<Enemy>())
			_hit.collider.GetComponent<Enemy>().takeDamage(damage*StaticVars.pistolMultiplier);
	}

	public void ContinuousFiring (){ 
		if (fireRate == GunType.Rifle || fireRate == GunType.Pistol)
			Shoot ();
	}

	public void Start () {
		gunSound = GetComponent<AudioSource> ();
		if (GetComponent<LineRenderer> ())
			tracer = GetComponent<LineRenderer> ();
		fireRateSpacing = 60 / roundsPerMinute;
	}
}
