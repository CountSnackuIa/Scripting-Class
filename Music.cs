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
	public List<float> drops;
	private int cubeCounter;

	// Use this for initialization
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
		drops.Add (29.856f);
		drops.Add (30.314f);
		drops.Add (31.253f);
		drops.Add (32.145f);
		drops.Add (33.037f);
		drops.Add (33.470f);
		drops.Add (33.928f);
		drops.Add (34.844f);
		drops.Add (35.735f);
		drops.Add (36.651f);
		drops.Add (37.109f);
		drops.Add (37.519f);
		drops.Add (38.410f);
		drops.Add (39.326f);
		drops.Add (40.217f);
		drops.Add (40.699f);
		drops.Add (41.133f);
		drops.Add (42.049f);
		drops.Add (42.940f);
		drops.Add (43.832f);
		drops.Add (44.314f);
		drops.Add (44.748f);
		drops.Add (45.639f);
		drops.Add (46.531f);
		drops.Add (47.47f);

		musicClip.Play();
		StartCoroutine ("SyncToAudio");
		StartCoroutine ("SyncBassToAudio");
	}

	IEnumerator SyncBassToAudio(){
		for (int k = 0; k < drops.Count; k++){
			// find the sample number equivalent to time_s[k]:
			float sampleCalc = drops[k] * musicClip.clip.frequency;
//			print (nSample);
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
//			MeshRenderer meshIsActive = speakers[speakerCounter].GetComponent<MeshRenderer>();
//			meshIsActive.enabled = !meshIsActive.enabled;
		}
	}
	IEnumerator SyncToAudio(){
		for (int k = 0; k < times.Count; k++){
			// find the sample number equivalent to time_s[k]:
			float sampleCalc = times[k] * musicClip.clip.frequency;
//			print (nSample);
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			if (cubeCounter >= cubes.Count)
				cubeCounter = 0;
			MeshRenderer meshIsActive = cubes[cubeCounter].GetComponent<MeshRenderer>();
			meshIsActive.enabled = !meshIsActive.enabled;
			cubeCounter++;
		}
	}
}