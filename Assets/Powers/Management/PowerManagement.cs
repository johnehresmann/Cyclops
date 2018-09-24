using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInputVR.Core;

public class PowerManagement : MonoBehaviour {

	public Abilities[] playerAbility;
	public GameObject playerCharacter;

	// Use this for initialization
	void Start () {

		foreach (ScriptableObject pAbility in playerAbility)
		{
			
		}	

		EasyInputVR.Misc.FirstPersonTurnAndShoot playerScript = playerCharacter.GetComponent<EasyInputVR.Misc.FirstPersonTurnAndShoot>();

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
