using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour {

	public float damage = .1f;
	public LayerMask collisionMask;
	public float roundsPerMinute;
	public Transform weaponSpawn;
	public AudioSource gunSound;
	public LineRenderer tracer;
	public float fireRateSpacing;
	public float nextShotTiming;

	public virtual void Contact(RaycastHit _hit)
	{
		if (_hit.collider.GetComponent<Enemy>()) //Enemy in this script
			_hit.collider.GetComponent<Enemy>().takeDamage(damage*StaticVars.pistolMultiplier);
	}

	public virtual void Shoot () {
		if (CanShoot ()) {
			Ray weaponDirection = new Ray (weaponSpawn.position, weaponSpawn.forward);
			RaycastHit hit;
			float weaponRange = 20;
			
			if (Physics.Raycast (weaponDirection, out hit, collisionMask)) {
				StaticVars.playerLookPosition = hit.point;
				weaponRange = hit.distance;
				Contact (hit);
			}
			gunSound.Play ();
			nextShotTiming = Time.time + fireRateSpacing;
			if (tracer)
				StartCoroutine("RenderTracer", weaponDirection.direction * weaponRange);
		}
	}

	public virtual void ContinuousFiring (){ //Different
		Shoot ();
	}

	public virtual bool CanShoot(){
		bool canShoot = true;
		if (Time.time < nextShotTiming && !StaticVars.titleMenuActive)
			canShoot = false;
		return canShoot;
	}

	IEnumerator RenderTracer(Vector3 destination) {
		tracer.enabled = true;
		tracer.SetPosition (0, weaponSpawn.position);
		tracer.SetPosition (1, weaponSpawn.position + destination);
		yield return null;
		tracer.enabled = false;
	}

	// Use this for initialization
	public virtual void Start () {
		gunSound = GetComponent<AudioSource> ();
		if (GetComponent<LineRenderer> ())
			tracer = GetComponent<LineRenderer> ();
	}
}
