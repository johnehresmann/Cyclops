using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

public abstract class mPower : ScriptableObject {

	//Declare Public Variables Here
	public string aName;
	public Camera pCamera;
	public AudioClip aAudio;
	public Transform spawnTransform;

	public GameObject aMesh;

	public abstract void Initialize(GameObject obj);
	public abstract void TriggerAbility();
}
