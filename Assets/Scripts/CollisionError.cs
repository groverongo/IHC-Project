using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionError : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLISIONES");
    }
}
