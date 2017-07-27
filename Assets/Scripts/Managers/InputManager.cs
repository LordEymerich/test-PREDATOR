using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NightVision))]
[RequireComponent(typeof(ThermalVision))]
public class InputManager : MonoBehaviour {

	private NightVision nightVisionScript;
	private ThermalVision thermalVisionScript;

	void Start()
	{
		nightVisionScript = GetComponent<NightVision>();
		thermalVisionScript = GetComponent<ThermalVision>();
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			DeactivateAllVisions();
		}

		if(Input.GetKey(KeyCode.Alpha2))
		{
			DeactivateAllVisions();
			nightVisionScript.enabled = true;
		}

		if(Input.GetKey(KeyCode.Alpha3))
		{
			DeactivateAllVisions(); 
			thermalVisionScript.enabled = true;
		}
	}

	private void DeactivateAllVisions()
	{
		nightVisionScript.enabled = false;
		thermalVisionScript.enabled = false;
	}
}
