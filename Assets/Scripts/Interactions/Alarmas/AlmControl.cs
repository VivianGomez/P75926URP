using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmControl : MonoBehaviour
{    
    public bool activated = false;

    private Renderer rendererComp;

    public AudioClip soundDownEnabled;
    

    void Start()
    {
        rendererComp = GetComponent<Renderer>();
    }

    public void ActivateAlarm()
    {
        activated = true;
        AudioSource.PlayClipAtPoint(soundDownEnabled, Vector3.zero, 1.0f);
        Color yColor = new Vector4(0.9811321f, 0.9691382f, 0.5692418f, 1f);
        rendererComp.material.SetColor("_Color", yColor);
        rendererComp.material.SetFloat("_Metallic", .0f);
        rendererComp.material.SetFloat("_Glossiness", .0f);
    }

    public void DisableAlarm()
    {
        activated = false;
        rendererComp.material.SetColor("_Color", Color.white);
        rendererComp.material.SetFloat("_Metallic", .53f);
        rendererComp.material.SetFloat("_Glossiness", .55f);
    }
}
