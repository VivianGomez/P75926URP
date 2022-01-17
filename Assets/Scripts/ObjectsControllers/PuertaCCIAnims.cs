using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PuertaCCIAnims : MonoBehaviour
{
    Animator anim;

    void Start() 
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    public int PlayAnimation(object animationName)
    {
        print("playing... "+ animationName);
        anim.SetBool("open", false);
        anim.SetBool("close", false);
        
        switch (animationName)
        {
            case "open":
                anim.SetBool("open", true);
                break;
            case "close":
                anim.SetBool("close", true);
                break;
        }
        return 1000;
    }
}
