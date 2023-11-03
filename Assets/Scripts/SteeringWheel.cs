using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    public float wheel_angle = 0;
    private float convertion_rate = (float)45 / (float)540;    // 540 control degrees = 45 wheel degrees 


    public void SetAngle(float control_angle)
    {
        wheel_angle = convertion_rate * control_angle;
    }

    void Update()
    {
        Debug.Log("SteeringWheel Angle: " + wheel_angle.ToString());
    }
}
