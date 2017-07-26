using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu ("Image Effects/Vision/Thermal Vision")]
public class ThermalVision : MonoBehaviour {

	public delegate void OnThermalVisionEnabledDelegate(bool enabled);
	public static event OnThermalVisionEnabledDelegate onThermalVisionEnabled;

	void OnEnable()
	{
		if(onThermalVisionEnabled!=null)onThermalVisionEnabled(true);
	}

	void OnDisable()
	{
		if(onThermalVisionEnabled!=null)onThermalVisionEnabled(false);
	}
		

//	void OnRenderImage(RenderTexture source, RenderTexture dest)
//	{
//		
//	}

}
