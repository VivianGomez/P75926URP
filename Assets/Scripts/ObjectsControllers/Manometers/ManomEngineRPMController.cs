using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManomEngineRPMController : ManomController
{
    void Start()
    {
        Initialize(0,12);
    }

    public void MoverIntervalo(object valorA,object valorB)
    {
        var nuevoValA = int.Parse(""+valorA);
        switch (nuevoValA)
        {
            case 5:
                Debug.Log("Manómetro se mueve a "+ valorA.ToString());
                aguja.GetComponent<Animator>().SetBool("lowPresure", true);
                break;
            default:
                Debug.Log("OTRO "+ valorA.ToString());
                break;
        }
    }
}
