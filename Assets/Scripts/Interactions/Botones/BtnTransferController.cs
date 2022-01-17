using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTransferController : BtnController
{
    AlmControl almMainbridgeInControl;
    AlmControl almEcs;
    string ladoMotor = "";

    void Awake()
    {
        ladoMotor = gameObject.name.Substring(gameObject.name.Length - 3);
        almMainbridgeInControl = GameObject.Find("AlmMainbridgeInControl"+ladoMotor).GetComponent<AlmControl>();
        almEcs = GameObject.Find("AlmEcs"+ladoMotor).GetComponent<AlmControl>();
    }

    protected override void Touched()
    {
        ActiveAnimation();
        if (almMainbridgeInControl.activated)
        {
            almEcs.ActivateAlarm();
            almMainbridgeInControl.DisableAlarm();
        }
        else
        {
            almEcs.DisableAlarm();
            almMainbridgeInControl.ActivateAlarm();
        }
        
        GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "Touched",""));
    }
}
