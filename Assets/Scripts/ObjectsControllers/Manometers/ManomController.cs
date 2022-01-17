using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManomController : MonoBehaviour
{
    static float minAngle = -30.0f;
    static float maxAngle = 210.0f;
    public GameObject aguja;

    public float min;
    public float max;

    public void Initialize(float pMin, float pMax)
    {
        min = pMin;
        max = pMax;
        aguja = transform.GetChild(0).gameObject;
    }

    public float DarValorManom(float val)
    {
        float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min,max,val));
        return ang;
    }

    public void MoverHasta(object valor)
    {
        aguja.transform.rotation =  Quaternion.Euler(-86f,0,DarValorManom(float.Parse(""+valor)));
    }
}
