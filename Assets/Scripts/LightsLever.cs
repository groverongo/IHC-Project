using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsLever : MonoBehaviour
{
    public bool light_left = false;
    public bool light_right = false;

    public void SetLeft()
    {
        Debug.Log("left");
        light_left = true;
        light_right = false;
    }

    public void SetRight()
    {
        Debug.Log("right");
        light_left = false;
        light_right = true;
    }

    public void SetNone()
    {
        Debug.Log("none");
        light_left = false;
        light_right = false;
    }

    void Update()
    {
        Debug.Log("Lights: " + light_left.ToString() + "-" + light_right.ToString());
    }
}
