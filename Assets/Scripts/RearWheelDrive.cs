using UnityEngine;

public class RearWheelDrive : MonoBehaviour
{
    #region --- helper ---
    [System.Serializable]
    public struct WheelInfo
    {
        public Transform visualwheel;
        public WheelCollider wheelcollider;
    }
    #endregion 

    #region --- helper ---
    [System.Serializable]
    public struct Gear_Info {
        public char letter;
        public KeyCode keyboard;
        public bool active;
    }
    #endregion 

    public float motor = 900; //800
    public float steer = 80; // 50
    public float brake = 800;
    public float friction_brake = 200;
    public WheelInfo FL;
    public WheelInfo FR;
    public WheelInfo BL;
    public WheelInfo BR;

    public Gear_Info P;
    public Gear_Info R;
    public Gear_Info N;
    public Gear_Info D;

    public Light[] lights = new Light[2];
    public GameObject lightOn;
    public GameObject lightOff;

    public HingeJoint steering_wheel;

    void Inactive_Gears() {
        P.active = false;
        R.active = false;
        N.active = false;
        D.active = false;
    }

    public void Gear_Active(ref Gear_Info gear_obj) {
        Inactive_Gears();
        gear_obj.active = true;
    }

    public void Gear_Change_P() {
        Gear_Active(ref P);
    }

    public void Gear_Change_N()
    {
        Gear_Active(ref N);
    }

    public void Gear_Change_R()
    {
        Gear_Active(ref R);
    }
    public void Gear_Change_D()
    {
        Gear_Active(ref D);
    }

    void Change_Gears() {
        if (Input.GetKeyDown(P.keyboard))
        {
            Gear_Active(ref P);
            Debug.Log("P: " + P.active + " R: " + R.active + " N: " + N.active + " D: " + D.active);
        }
        else if (Input.GetKeyDown(N.keyboard))
        {
            Gear_Active(ref N);
            Debug.Log("P: " + P.active + " R: " + R.active + " N: " + N.active + " D: " + D.active);
        }
        else if (Input.GetKeyDown(D.keyboard))
        {
            Gear_Active(ref D);
            Debug.Log("P: " + P.active + " R: " + R.active + " N: " + N.active + " D: " + D.active);
            Debug.Log(" AXIS: " + BL.wheelcollider.motorTorque.ToString() + " MOTOR: "+BR.wheelcollider.motorTorque+ " BRAKE: "+BR.wheelcollider.brakeTorque);
        }
        else if (Input.GetKeyDown(R.keyboard))
        {
            Gear_Active(ref R);
            Debug.Log("P: " + P.active + " R: " + R.active + " N: " + N.active + " D: " + D.active);

        }

    }

    void Assign_Gear_Info() {
        Inactive_Gears();
        P.letter = 'P';
        R.letter = 'R';
        N.letter = 'N';
        D.letter = 'D';
        P.active = true;
    }

    private void Start()
    {
        GetTheWheels();
        Assign_Gear_Info();
    }
    
    private void FixedUpdate()
    {
        Change_Gears();
        Debug.Log("Steering-Wheel Angle: " + steering_wheel.angle.ToString());

        //steer and accelerate car (wasd, arrows, leftanalog gamepad)
        float vert = Input.GetAxis("Vertical");
        vert *= (P.active || N.active ? 0 : 1);  //-1..0..1
        if (vert >= 0)
        {
            vert *= (D.active ? 1 : -1);
            BL.wheelcollider.motorTorque = vert * motor;
            BR.wheelcollider.motorTorque = vert * motor;
            FL.wheelcollider.brakeTorque = 0;
            FR.wheelcollider.brakeTorque = 0;
            BL.wheelcollider.brakeTorque = 0;
            BR.wheelcollider.brakeTorque = 0;
            //foreach (Light light in lights)
            //light.enabled = false;
            
            lightOff.SetActive(true);
            lightOn.SetActive(false);
        }
        else {
            vert = (vert < 0 ? vert * -1 : vert);
            FL.wheelcollider.brakeTorque = vert*brake;
            FR.wheelcollider.brakeTorque = vert*brake;
            BL.wheelcollider.brakeTorque = vert*brake;
            BR.wheelcollider.brakeTorque = vert*brake;
            //foreach (Light light in lights)
            //light.enabled = true;
            lightOn.SetActive(true);
            lightOff.SetActive(false);
        }
        
        float horz = Input.GetAxis("Horizontal");
        FL.wheelcollider.steerAngle = horz * steer;
        FR.wheelcollider.steerAngle = horz * steer;

        Debug.Log("Horizontal: "+horz.ToString());

        UpdateVisualWheels();
    }
    private void UpdateVisualWheels()
    {
        Vector3 pos;
        Quaternion rot;

        FL.wheelcollider.GetWorldPose(out pos, out rot);
        FL.visualwheel.position = pos;
        FL.visualwheel.rotation = rot;

        FR.wheelcollider.GetWorldPose(out pos, out rot);
        FR.visualwheel.position = pos;
        FR.visualwheel.rotation = rot;

        BL.wheelcollider.GetWorldPose(out pos, out rot);
        BL.visualwheel.position = pos;
        BL.visualwheel.rotation = rot;

        BR.wheelcollider.GetWorldPose(out pos, out rot);
        BR.visualwheel.position = pos;
        BR.visualwheel.rotation = rot;
    }
    private void GetTheWheels()
    {
        GameObject wheels = GetChildByName(this.gameObject, "Wheels");
        FL.visualwheel = GetChildByName(wheels, "Tire_Front_L").transform;
        FR.visualwheel = GetChildByName(wheels, "Tire_Front_R").transform;
        BL.visualwheel = GetChildByName(wheels, "Tire_Back_L").transform;
        BR.visualwheel = GetChildByName(wheels, "Tire_Back_R").transform;

        GameObject colliders = GetChildByName(this.gameObject, "Wheel Colliders");
        FL.wheelcollider = GetChildByName(colliders, "WC_Tire_Front_L").GetComponent<WheelCollider>();
        FR.wheelcollider = GetChildByName(colliders, "WC_Tire_Front_R").GetComponent<WheelCollider>();
        BL.wheelcollider = GetChildByName(colliders, "WC_Tire_Back_L").GetComponent<WheelCollider>();
        BR.wheelcollider = GetChildByName(colliders, "WC_Tire_Back_R").GetComponent<WheelCollider>();
    }
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
}