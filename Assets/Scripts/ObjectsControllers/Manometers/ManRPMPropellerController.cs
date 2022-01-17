using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManRPMPropellerController : ManomController
{
    void Start()
    {
        Initialize(0,400);
        MoverHasta(300f);
    }
}
