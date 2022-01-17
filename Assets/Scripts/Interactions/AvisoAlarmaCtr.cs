using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoAlarmaCtr : MonoBehaviour
{
    bool pTouched = false;

    public void Pressed()
    {
        GameObject.Find("AMS").GetComponent<PntAlarmasController>().MostrarAlarmas();
        GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "Pressed",""));
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (!pTouched && other.tag =="IndexFinger")
        {
            pTouched = true;
            Pressed();
            yield return new WaitForSeconds(0.5f);    
            pTouched = false;    
        }
    }
}
