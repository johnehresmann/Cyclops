using System.Collections;
using UnityEngine;
using DarkTonic.CoreGameKit;

public abstract class Abilities : ScriptableObject {

	// Use this for initialization
	[Header("Universal Attributes")]
	public string abilityName = "Ability Name Here";
	public bool isEnabled = true;
	public float fireDelay = 1.0f;
	public GameObject projectile;

	public abstract void fireAbility(GameObject projectile, Transform spawnTransform, float projectileSpeed);

}
