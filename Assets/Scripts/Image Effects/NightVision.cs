using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu ("Image Effects/Vision/Night Vision")]
public class NightVision : MonoBehaviour
{

	[Range (1, 10)] public float LuminanceAmplifier;
	[Range (0, 1)] public float noiseIntensity;
	public Texture noiseMap;

	private Material nightVisionMaterial;

	void Start ()
	{
		if (!SystemInfo.supportsImageEffects) {
			enabled = false;
			return;
		}

		nightVisionMaterial = new Material (Shader.Find ("Hidden/Night Vision"));

		nightVisionMaterial.SetFloat ("_LuminanceAmplifier", LuminanceAmplifier);
		nightVisionMaterial.SetFloat ("_NoiseIntensity", noiseIntensity);
		nightVisionMaterial.SetTexture ("_NoiseTex", noiseMap);
	}

	void Update ()
	{
		#if UNITY_EDITOR
		nightVisionMaterial.SetFloat ("_LuminanceAmplifier", LuminanceAmplifier);
		nightVisionMaterial.SetFloat ("_NoiseIntensity", noiseIntensity);
		nightVisionMaterial.SetTexture ("_NoiseTex", noiseMap);
		#endif
	}

	void OnRenderImage (RenderTexture source, RenderTexture dest)
	{
		Graphics.Blit (source, dest, nightVisionMaterial);	
	}
}
