using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour {

	public AudioSource musicClip;
	public List<GameObject> cubes;
	public List<GameObject> speakers;
	public List<float> times;
	private float[] dropsArray = new float[]{29.856f, 30.314f, 31.253f, 32.145f, 33.037f, 33.470f, 33.928f, 34.844f, 35.735f, 36.651f, 37.109f, 37.519f, 38.410f, 39.326f, 40.217f, 
		40.699f, 41.133f, 42.049f, 42.940f, 43.832f, 44.314f, 44.748f, 45.639f, 46.531f, 47.47f};
	private int cubeCounter;

	void Start () {
		foreach(GameObject item in speakers)
		{
			MeshRenderer meshIsActive = item.GetComponent<MeshRenderer>();
			meshIsActive.enabled = false;
		}

		for( int i = 0; i < 200; i++)
			{
				times.Add (1 + (i * .227f));
			}

		musicClip.Play();
		StartCoroutine ("SyncToAudio");
		StartCoroutine ("SyncBassToAudio");
	}

	IEnumerator SyncBassToAudio(){
		for (int k = 0; k < dropsArray.Length; k++){
			float sampleCalc = dropsArray[k] * musicClip.clip.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			foreach(GameObject item in speakers)
			{
				MeshRenderer meshIsActive = item.GetComponent<MeshRenderer>();
				meshIsActive.enabled = !meshIsActive.enabled;
			}
			yield return new WaitForSeconds (.1f);
			foreach(GameObject item in speakers)
			{
				MeshRenderer meshIsActive = item.GetComponent<MeshRenderer>();
				meshIsActive.enabled = !meshIsActive.enabled;
			}
		}
	}
	IEnumerator SyncToAudio(){
		for (int k = 0; k < times.Count; k++){
			float sampleCalc = times[k] * musicClip.clip.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			if (cubeCounter >= cubes.Count)
				cubeCounter = 0;
			MeshRenderer meshIsActive = cubes[cubeCounter].GetComponent<MeshRenderer>();
			meshIsActive.enabled = !meshIsActive.enabled;
			cubeCounter++;
		}
	}
}
