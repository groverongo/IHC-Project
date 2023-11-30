using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkLights : MonoBehaviour
{

    public ButtonEmergency emergency;

    public Light[] right_lights = new Light[2];
    public Light[] left_lights = new Light[2];
    public KeyCode right_keyboard;
    public KeyCode left_keyboard;
    public KeyCode hazard_keyboard;

    // Lights times
    public float timer;
    public float blink_time;
    // Lights coordinator
    public bool lights_on = false;
    // Toggle lights
    public bool toggle_right = false;
    public bool toggle_left = false;
    public bool toggle_hazard = false;

    private bool right_lever_first = false;

    public LightsLever lights_lever;

    public GameObject LLight_Display;
    public GameObject RLight_Display;

    private Sound_Manager this_sound_manager;

    ButtonEmergency ButtonToggle;

    private GameObject GetChildByName(GameObject go, string name)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            if (go.transform.GetChild(i).name == name)  //case sensitive
            {
                return go.transform.GetChild(i).gameObject;
            }
        }

        Debug.LogError("ERR: Could not find child gameobject " + name + ". Check spelling and case.");
        return null;
    }

    private void Start()
    {
        // Init timer
        timer = blink_time;
        RLight_Display.SetActive(false);
        LLight_Display.SetActive(false);
        this_sound_manager = GetComponent<Sound_Manager>();


        ButtonToggle = GetChildByName(GetChildByName(this.gameObject, "Interactables"), "ButtonToggle").GetComponent<ButtonEmergency>();
    }


    // Turn Lights on and off
    void UpdateLights()
    {
        // Update lights
        bool left_on = (toggle_left || toggle_hazard) && lights_on;
        bool right_on = (toggle_right || toggle_hazard) && lights_on;


        foreach (Light light in right_lights)
        {
            light.enabled = right_on;
            RLight_Display.SetActive(right_on);
        }
        foreach (Light light in left_lights)
        {
            light.enabled = left_on;
            LLight_Display.SetActive(left_on);
        }
    }

    // Update timer
    void Blink_Light()
    {
        if (timer > 0)
        {
            // Update timer
            timer -= Time.deltaTime;
        }
        else
        {
            lights_on = !lights_on;
            timer = blink_time;
            UpdateLights();
        }
    }

    void Hazard_Lights_Blink()
    {
        toggle_hazard = emergency.active;
        UpdateLights();
        /*
        if (emergency.active ||Input.GetKeyDown(hazard_keyboard))
        {
            toggle_hazard = !toggle_hazard;
            UpdateLights();
        }
        */

    }

    void Right_Lights_Blink()
    {
        if (Input.GetKeyDown(right_keyboard) || (lights_lever.light_right && !toggle_right) || (!lights_lever.light_left && !lights_lever.light_right && toggle_right))
        {
            toggle_left = false;
            toggle_right = !toggle_right;
            UpdateLights();
        }
    }
    void Left_Lights_Blink()
    {
        if (Input.GetKeyDown(left_keyboard) || (lights_lever.light_left && !toggle_left) || (!lights_lever.light_left && !lights_lever.light_right && toggle_left))
        {
            toggle_right = false;
            toggle_left = !toggle_left;
            UpdateLights();
        }
    }

    void Update()
    {

        Debug.Log("CHILD BUTTON TOGGLE ACTIVE: "+ButtonToggle.active.ToString());
        this_sound_manager.toggle_blinking(ButtonToggle.active || lights_lever.light_left || lights_lever.light_right);

        Right_Lights_Blink();
        Left_Lights_Blink();
        Hazard_Lights_Blink();
        if (toggle_right || toggle_left || toggle_hazard)
            Blink_Light();

        Debug.Log("Directional Angle: ");
    }
}