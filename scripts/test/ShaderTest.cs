using UnityEngine;

public class ShaderTest : MonoBehaviour
{
	public Material lightsaberMaterial;
	public float speed = 2.0f;

	void Update()
	{
		if (lightsaberMaterial)
		{
			lightsaberMaterial.SetFloat("_ColorShiftSpeed", speed);
		}
	}
}
