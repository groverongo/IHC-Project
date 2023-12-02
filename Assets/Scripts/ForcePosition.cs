using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePosition : MonoBehaviour
{
    //create a position object 

    public Vector3 defaultPosition;
    public GameObject parent;
    //Vector3(-0.425291121,0.739410996,-0.182469025)




    // Start is called before the first frame update
    void Start()
    {
        defaultPosition =  transform.position - parent.transform.position ;

        
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the parent object
        Vector3 parentPosition = parent.transform.position;

        //set the position of the object to the parent position
        // transform.position = parentPosition + defaultPosition;
        // transorm set local position
        transform.localPosition = new Vector3(0,0,0);

        Debug.Log("Parent Position: "  + transform.position.ToString());
        
    }
}
