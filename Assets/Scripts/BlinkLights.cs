using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLights : MonoBehaviour
{

	public Light[] right_lights = new Light[2];
	public Light[] left_lights = new Light[2];
	public KeyCode right_keyboard;
	public KeyCode left_keyboard;
	public KeyCode hazard_keyboard;
	public float blink_time;
	public float timer;
	public bool toggle_right = false;
	public bool toggle_left = false;
	public bool toggle_hazard = false;


	private void Start()
    {
		timer = blink_time;
    }

    // Direccionales
    void Blink_Light() {
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else {
			if(toggle_right || toggle_hazard)
				foreach (Light light in right_lights)
				{
					light.enabled = !light.enabled;
				}
			if(toggle_left || toggle_hazard)
				foreach (Light light in left_lights)
				{
					light.enabled = !light.enabled;
				}
			timer = blink_time;
		}
	}

	void Hazard_Lights_Blink() {
		if (Input.GetKeyDown(hazard_keyboard)) {
			toggle_hazard = !toggle_hazard;
		}
	}

	void Right_Lights_Blink()
    {
		if (Input.GetKeyDown(right_keyboard))
		{
			toggle_left = false;
			foreach (Light light in left_lights)
				light.enabled = false;
			if (toggle_right)
			{
				foreach (Light light in right_lights)
					light.enabled = false;
			}

			toggle_right = !toggle_right;
		}
	}
	void Left_Lights_Blink()
	{
		if (Input.GetKeyDown(left_keyboard))
		{
			toggle_right = false;
			foreach (Light light in right_lights)
				light.enabled = false;
			if (toggle_left)
			{
				foreach (Light light in left_lights)
					light.enabled = false;
			}

			toggle_left = !toggle_left;
		}
	}

	void Update()
	{
		Right_Lights_Blink();
		Left_Lights_Blink();
		Hazard_Lights_Blink();
		if(toggle_right || toggle_left || toggle_hazard)
			Blink_Light();
	
	}
}