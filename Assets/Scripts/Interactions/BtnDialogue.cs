using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDialogue : MonoBehaviour
{
    public Animator screenMenuAnim;
    public bool activated = false;


    void Start() {
        activated = false;
    }

    public void ActiveAnimation()
    {
        activated = !activated;

        if (activated)
        {
            screenMenuAnim.SetBool("open", true);
        }
        else
        {
            screenMenuAnim.SetBool("close", true);
        }
    }
}