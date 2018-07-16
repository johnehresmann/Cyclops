using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MasterProjectile : MonoBehaviour {

	// Use this for initialization
	
	Rigidbody projectileRigid;

	private Transform prefabTransform;
	private Transform trans;

	private EasyInputVR.Misc.FirstPersonTurnAndShoot fpsTurn;

	#region Player Variables

	public float shotSpeed = 40f;

	#endregion
	
	void Start () {

		
				
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		this.transform.Translate(0,0,shotSpeed * Time.deltaTime);	
		
	}
}
