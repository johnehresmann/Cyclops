using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterProjectile : MonoBehaviour 
{
	public float projectileSpeed = 10;
	public GameObject playerObject;

	public LayerMask playerLayer = 9;
	

	void Start()
	{
		
	
	}
		/* Camera playerCamera = playerObject.GetComponent<Camera>();
		Transform cameraTransform = playerCamera.transform;
		this.transform.forward += cameraTransform.forward * projectileSpeed; */
	void Update()
	{
		if (Physics.Raycast(transform.position, transform.forward, 100, playerLayer.value))
			Debug.Log("Player");
		
	}
}