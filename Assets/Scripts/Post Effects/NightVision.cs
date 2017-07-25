using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVision : MonoBehaviour {

	public bool enabled;
	[Range(1,5)] public float LuminanceAmplifier;

	private Material nightVisionMaterial;

	void Start () {
		nightVisionMaterial = new Material(Shader.Find("Hidden/Night Vision"));
	}

	void Update()
	{
		nightVisionMaterial.SetFloat("_LuminanceAmplifier", LuminanceAmplifier);
	}

	void OnRenderImage(RenderTexture source, RenderTexture dest)
	{
		if(enabled)
		{
			Graphics.Blit(source, dest, nightVisionMaterial);	
		}
		else
		{
			Graphics.Blit(source, dest);	
		}
	}
}
