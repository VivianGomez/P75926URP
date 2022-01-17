using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetection : MonoBehaviour
{
    public bool touched = false;
    void OnTriggerEnter(Collider other)
    {
        if(!touched && (other.gameObject.name=="RightHandAnchor" || other.gameObject.name=="LeftHandAnchor"))
        {
            GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "Grabbed",""));
            touched = true;
        }
    }

}
