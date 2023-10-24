using UnityEngine;
using System.Collections;

public class on_off_light : MonoBehaviour
{

	public Light[] lights;
	public KeyCode keyboard;



	// Direccionales

	void Update ()
	{
		foreach (Light light in lights)
		{
			if (Input.GetKeyDown(keyboard))
			{
				light .enabled = !light .enabled;
			}
		}
	}
}

