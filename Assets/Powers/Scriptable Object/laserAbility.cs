using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

[CreateAssetMenu(menuName = "Cyclops/Abilities/Laser Ability")]
public class laserAbility : Abilities {

	[SerializeField]
	public Color laserColor = Color.white;
	[SerializeField]
	[HideInInspector]private LineRenderer lr;
	float laserRange = 100f;
	// Use this for initialization
	public override void fireAbility(GameObject projectile, Transform spawnTransform, float projectileSpeed)
	{
		lr = projectile.GetComponent<LineRenderer>();
		lr.SetPosition(0, spawnTransform.position);
		lr.SetColors(laserColor, laserColor);
		RaycastHit hit;	

		if (Physics.Raycast(spawnTransform.position, spawnTransform.forward, out hit, laserRange))
		{
			if (hit.collider)
			{
				lr.SetPosition(1, hit.point);
				Debug.Log("Hit");
			}
		}
		
		else lr.SetPosition(1, spawnTransform.forward*5000);
	}
}
