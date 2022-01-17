using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTutorial : MonoBehaviour
{
    private Animator animator;

    // Control de activación 
    public bool activated = false;
    public bool pTouched = false;
    private Renderer rendererComp;

    public AudioClip soundDownEnabled;
    public AudioClip soundDownDisabled;

    void Start()
    {
        animator = GetComponent<Animator>();
        rendererComp = GetComponent<Renderer>();   
        pTouched = false;
    }

    public void ActiveAnimation()
    {
        activated = !activated;
        animator.SetBool("pressed", activated);

        if (activated)
        {
            AudioSource.PlayClipAtPoint(soundDownEnabled, Vector3.zero, 5.0f);
            rendererComp.material.SetFloat("_Metallic", .0f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(soundDownDisabled, Vector3.zero, 1.0f);
            rendererComp.material.SetFloat("_Metallic", 0.6f);
        }
    }

    public void Touched()
    {
        ActiveAnimation();
        GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "Touched",""));
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (!pTouched && other.tag =="IndexFinger")
        {
            pTouched = true;
            Touched();
            yield return new WaitForSeconds(0.5f);    
            pTouched = false;    
        }
    }
}
