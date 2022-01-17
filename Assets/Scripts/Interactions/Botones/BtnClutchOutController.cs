using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClutchOutController : BtnController
{
    ManRPMPropellerController manRPMPropellerController;
    string ladoMotor = "";

    void Awake()
    {
        ladoMotor = gameObject.name.Substring(gameObject.name.Length - 3);
        manRPMPropellerController = GameObject.Find("ManPropeller"+ladoMotor).GetComponent<ManRPMPropellerController>();
    }

    protected override void Touched()
    {
        ActiveAnimation();
        manRPMPropellerController.MoverHasta(0);
        GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "Touched",""));
    }
}
