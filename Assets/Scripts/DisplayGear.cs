using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayGear : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI text;
    void Start()
    {
        text.text = "No Gear";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
