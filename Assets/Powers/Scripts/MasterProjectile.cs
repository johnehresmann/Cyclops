using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;
public class MasterProjectile : MonoBehaviour 
{
	GameObject playerObj;
	
	void Start()
	{
		

	}
	public void fireProjectile(GameObject projectile, Transform spawnTransform, float projectileSpeed) {

		playerObj = GameObject.Find("Player");

		 EasyInputVR.Misc.FirstPersonTurnAndShoot playerFPS = playerObj.GetComponent<EasyInputVR.Misc.FirstPersonTurnAndShoot>();

		Transform newObject = PoolBoss.SpawnOutsidePool(projectile.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
                Rigidbody newRigidBody = newObject.GetComponent<Rigidbody>();
                newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed);
	}
}