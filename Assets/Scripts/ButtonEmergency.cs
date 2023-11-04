using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEmergency : MonoBehaviour
{
    public bool active=false;

    // Start is called before the first frame update
    public void SetActive()
    {
        active = true;
    }

    public void UnsetActive()
    {
        active = false;
    }


    void Update()
    {
        Debug.Log("ButtonEmergency State: " + active.ToString());
    }
}
