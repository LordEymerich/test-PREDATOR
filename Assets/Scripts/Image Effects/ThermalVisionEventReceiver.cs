using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalVisionEventReceiver : MonoBehaviour {

	[Range(0.5f, 1.5f)] public float averageTemperature;

	private Material thermalBody;
	private List<Material> orignalMaterials;
	private List<Material> thermalBodyMaterials;
	private MeshRenderer meshRenderer;
	private SkinnedMeshRenderer skinnedMeshRenderer;

	void Awake()
	{
		orignalMaterials = new List<Material>();
		thermalBodyMaterials = new List<Material>();

		// Take reference of MeshRenderer or SkinnedMeshRenderer (also for animated characters).
		meshRenderer = GetComponent<MeshRenderer>();
		if(meshRenderer == null)
		{
			skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
		}
	}

	void Start () 
	{
		// Save original materials to be restored if thermal vision is not active.
		if(meshRenderer != null)
		{
			orignalMaterials.AddRange(meshRenderer.materials);
		}
		else
		{
			orignalMaterials.AddRange(skinnedMeshRenderer.materials);
		}

		thermalBody = new Material(Shader.Find("Vision/Thermal Body"));
		thermalBody.SetFloat("_Temperature", averageTemperature);

		// to be more generic it is considering also meshes with multiple materials where every material must be replaced.
		for(int i = 0; i < orignalMaterials.Count; i++)
		{
			thermalBodyMaterials.Add(thermalBody);
		}

		ThermalVision.onThermalVisionEnabled += OnThermalModeChange;
	}

	void OnThermalModeChange (bool enabled)
	{
		if(enabled)
		{
			// TODO: this must not be hard coded!!!
			gameObject.layer = 8;

			if(meshRenderer != null)
			{
				meshRenderer.materials = thermalBodyMaterials.ToArray();
			}
			else if (skinnedMeshRenderer != null)
			{
				skinnedMeshRenderer.materials = thermalBodyMaterials.ToArray();
			}
		}
		else 
		{
			// TODO: this must not be hard coded!!!
			gameObject.layer = 0;

			if(meshRenderer != null)
			{
				meshRenderer.materials = orignalMaterials.ToArray();		
			}
			else if (skinnedMeshRenderer != null)
			{
				skinnedMeshRenderer.materials = orignalMaterials.ToArray();
			}
		}
	}
}
