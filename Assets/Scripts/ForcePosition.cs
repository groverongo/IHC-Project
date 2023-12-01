using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePosition : MonoBehaviour
{
    //create a position object 

    public Vector3 defaultPosition;
    //Vector3(-0.425291121,0.739410996,-0.182469025)




    // Start is called before the first frame update
    void Start()
    {
        defaultPosition =  transform.position - transform.parent.position ;
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the parent object
        Vector3 parentPosition = transform.parent.position;

        //set the position of the object to the parent position
        transform.position = parentPosition + defaultPosition;
        
    }
}
