using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

[CreateAssetMenu(menuName = "Cyclops/Abilities/Blast Power")]
public class explosivePower : Abilities {

	// Use this for initialization
	public override void fireAbility(GameObject projectile, Transform spawnTransform, float projectileSpeed)
	{
		Transform newAbility = PoolBoss.SpawnOutsidePool(projectile.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
	 	Rigidbody newRigidBody = newAbility.GetComponent<Rigidbody>();
        newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed);
		Debug.Log("Test");	
	} 	

}


