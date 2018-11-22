 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

[CreateAssetMenu (menuName = "Centauri/Abilities/baseAbility")]
public class baseAbility : mPower {

	//Initialize Decleration here
	public int abilityPower = 10;
	public float weaponRange = 50f;
	public float hitForce = 100f;
	public Color laserColor = Color.blue;

	[HideInInspector] public RaycastShootTriggerable rcShoot;
	
	public override void Initialize(GameObject obj)
	{
		rcShoot = obj.GetComponent<RaycastShootTriggerable> ();
		rcShoot.Initialize();

		rcShoot.abilityPower = abilityPower;
		rcShoot.weaponRange = weaponRange;
		rcShoot.hitForce = hitForce;
		rcShoot.laserLine.material = new Material(Shader.Find("Unlit/Color"));
		rcShoot.laserLine.material.color = laserColor;
	}

	//Shoot Ability here
	public override void TriggerAbility()
	{
		rcShoot.Fire();

	}

}
