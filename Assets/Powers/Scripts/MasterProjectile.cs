using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;
public class MasterProjectile : MonoBehaviour 
{
	GameObject playerObj;
	float speed;
	EasyInputVR.Misc.FirstPersonTurnAndShoot plyrScript;
	
	void Start()
	{
		plyrScript = GameObject.Find("Player").GetComponent<EasyInputVR.Misc.FirstPersonTurnAndShoot>();
		speed = plyrScript.projectileSpeed;	
		

	}
	
	void Update() {
		

	}
	
	public void fireProjectile(GameObject projectile, Transform spawnTransform, float projectileSpeed) {

		if (speed != 0)
		{
			transform.position += transform.forward * (speed * Time.deltaTime);
		}else {
			Debug.Log("No Speed");
		}

		/* playerObj = GameObject.Find("Player");

		 EasyInputVR.Misc.FirstPersonTurnAndShoot playerFPS = playerObj.GetComponent<EasyInputVR.Misc.FirstPersonTurnAndShoot>();

		Transform newObject = PoolBoss.SpawnOutsidePool(projectile.transform, spawnTransform.transform.position, spawnTransform.transform.rotation);
                Rigidbody newRigidBody = newObject.GetComponent<Rigidbody>();
                newRigidBody.AddForce((spawnTransform.forward)*projectileSpeed) */;
	}
}