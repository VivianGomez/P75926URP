using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReset : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;


    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Plano Piso")
        {    
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
