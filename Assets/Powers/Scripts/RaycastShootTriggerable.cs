using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

public class RaycastShootTriggerable : MonoBehaviour {
	[HideInInspector] public float weaponRange = 100f;
	[HideInInspector] public int abilityPower = 10;
	[HideInInspector] public float fireSpeed = 1.0f;
	[HideInInspector] public float fireDelay = 2f;
	[HideInInspector] public float fireLength = 7f;
	[HideInInspector] public int maxAmmo = 20;
	[HideInInspector] public int startingAmmo = 20;
	[HideInInspector] public float hitForce = 100;
	[HideInInspector] public LineRenderer laserLine;
	private Camera pCamera;
	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

	public void Initialize ()
	{
		laserLine = GetComponent<LineRenderer> ();
		pCamera = GetComponentInParent<Camera> ();
	}

	public void Fire()
	{
		//Creating a vector at the center of the camera near clip plane
		Vector3 rayOrigin = pCamera.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));

		//Draw a debug line
		Debug.DrawRay (rayOrigin, pCamera.transform.forward * weaponRange, Color.green);

		//Declare a raycast hit to store information about what our raycast has hit
		RaycastHit hit;

		//Start our shot effect coroutine to turn out laser line on and off
		StartCoroutine(ShotEffect());

		//Check if Raycast hit anything
		if (Physics.Raycast(rayOrigin,pCamera.transform.forward, out hit, weaponRange))
		{
			//Set the end position for the laser line
			laserLine.SetPosition(1, hit.point);

			//get a referance to a health scrip attached to the collider we hit
			DarkTonic.CoreGameKit.Killable health = hit.collider.GetComponent<DarkTonic.CoreGameKit.Killable>();
			if (health != null)
			{
				health.TakeDamage(abilityPower);
			}

			if (hit.rigidbody != null)
			{
				//Add force
				hit.rigidbody.AddForce(-hit.normal *hitForce);
			}
		}
		else
		{
			//if we did not hit anything, set the end of line position to a position directly away
			laserLine.SetPosition(1, pCamera.transform.forward * weaponRange);
		}
		
	}

	private IEnumerator ShotEffect()
	{
		//Turn on our line renderer
		laserLine.enabled = true;
		
		//Wait for .07 seconds
		yield return fireLength;

		//deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
}
