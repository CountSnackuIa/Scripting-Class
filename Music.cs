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
	private float[] dropsArray = new float[25];
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
		dropsArray[0] = 29.856f;
		dropsArray[1] = 30.314f;
		dropsArray[2] = 31.253f;
		dropsArray[3] = 32.145f;
		dropsArray[4] = 33.037f;
		dropsArray[5] = 33.470f;
		dropsArray[6] = 33.928f;
		dropsArray[7] = 34.844f;
		dropsArray[8] = 35.735f;
		dropsArray[9] = 36.651f;
		dropsArray[10] = 37.109f;
		dropsArray[11] = 37.519f;
		dropsArray[12] = 38.410f;
		dropsArray[13] = 39.326f;
		dropsArray[14] = 40.217f;
		dropsArray[15] = 40.699f;
		dropsArray[16] = 41.133f;
		dropsArray[17] = 42.049f;
		dropsArray[18] = 42.940f;
		dropsArray[19] = 43.832f;
		dropsArray[20] = 44.314f;
		dropsArray[21] = 44.748f;
		dropsArray[22] = 45.639f;
		dropsArray[23] = 46.531f;
		dropsArray[24] = 47.47f;

		musicClip.Play();
		StartCoroutine ("SyncToAudio");
		StartCoroutine ("SyncBassToAudio");
	}

	IEnumerator SyncBassToAudio(){
		for (int k = 0; k < dropsArray.Length; k++){
			// find the sample number equivalent:
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
