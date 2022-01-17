using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPointCtr : MonoBehaviour
{
    public GameObject OtherTP;
    public bool active = false;
    public bool onceTime = false;

    void OnTriggerEnter(Collider other)
    {
        if(active && other.gameObject.name=="PlayerController")
        {
            if(OtherTP!=null)
            {
                OtherTP.SetActive(false);
            }
            GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "CompleteTPPoint",""));
            
            if(onceTime){active=false;}
        }
    }

    public void DisableTPPoint()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveState(object state)
    {
        if(state.ToString()=="true")
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }


}
