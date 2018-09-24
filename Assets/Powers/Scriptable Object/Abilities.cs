using System.Collections;
using UnityEngine;
using DarkTonic.CoreGameKit;

public abstract class Abilities : ScriptableObject {

	// Use this for initialization
	[Header("Universal Attributes")]
	public string abilityName = "Ability Name Here";
	public GameObject projectile;
	public bool isEnabled = true;
	[SerializeField]
	public float fireDelay = 1.0f;
	[SerializeField]
	public float pSpeed = 20f;
	[Header("Touch Conditions")]
	[SerializeField]
	public bool isLongTouch = false;
	[SerializeField]
	public bool isquickTouch = false;

	

	public abstract void fireAbility(GameObject projectile, Transform spawnTransform, float projectileSpeed);

}
