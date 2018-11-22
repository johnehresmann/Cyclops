using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DarkTonic.CoreGameKit;

public class PowerManager : EditorWindow 
{	
	public mPower[] pPower;
	public int abilityPower;
	
	[MenuItem("Window/Centauri/Centauri Power Manager")]
	public static void ShowWindow()
	{
		GetWindow<PowerManager>("Centauri Power Manager");

		

	}

	void OnGUI()
	{
		GUILayout.Label("Testing");

	}

}
