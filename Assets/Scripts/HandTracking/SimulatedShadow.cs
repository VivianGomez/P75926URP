using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedShadow : MonoBehaviour
{
    void Update()
    {
        Vector3 cam = GameObject.Find("CenterEyeAnchor").transform.position;
        transform.position = new Vector3(cam.x, transform.position.y, cam.z);
    }
}
