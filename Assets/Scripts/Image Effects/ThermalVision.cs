using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu ("Image Effects/Vision/Thermal Vision")]
public class ThermalVision : MonoBehaviour
{

	public delegate void OnThermalVisionEnabledDelegate (bool enabled);

	public static event OnThermalVisionEnabledDelegate onThermalVisionEnabled;

	[Range (0, 5)] public float noiseIntensity;
	public Texture noiseMap;

	private Material thermalVisionMaterial;

	void Start ()
	{
		if (!SystemInfo.supportsImageEffects) {
			enabled = false;
			return;
		}

		thermalVisionMaterial = new Material (Shader.Find ("Hidden/Thermal Vision"));

		thermalVisionMaterial.SetFloat ("_NoiseIntensity", noiseIntensity);
		thermalVisionMaterial.SetTexture ("_NoiseTex", noiseMap);
	}

	void Update ()
	{
		#if UNITY_EDITOR
		thermalVisionMaterial.SetFloat ("_NoiseIntensity", noiseIntensity);
		thermalVisionMaterial.SetTexture ("_NoiseTex", noiseMap);
		#endif
	}

	void OnEnable ()
	{
		if (onThermalVisionEnabled != null)
		{
			onThermalVisionEnabled (true);
		}
	}

	void OnDisable ()
	{
		if (onThermalVisionEnabled != null)
		{
			onThermalVisionEnabled (false);
		}
	}
		
	void OnRenderImage (RenderTexture source, RenderTexture dest)
	{
		Graphics.Blit (source, dest, thermalVisionMaterial);	
	}

}