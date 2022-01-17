using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using System;


public class PuertaArmarioAnim : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public int PlayAnimation(object animationName)
    {
        print("playing... "+ animationName);
        anim.SetBool("open", false);
        anim.SetBool("close", false);
        
        switch (animationName)
        {
            case "AbrirPuerta":
                anim.SetBool("open", true);
                break;
            case "CerrarPuerta":
                anim.SetBool("close", true);
                break;
        }
        return (int.Parse(""+ Convert.ToInt32(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length*1000)));;
    }

}
