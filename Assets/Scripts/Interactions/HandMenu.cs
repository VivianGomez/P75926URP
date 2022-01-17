using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HandMenu : MonoBehaviour
{
    public Animator screenMenuAnim;

    public GameObject handMenuBtn;
    public Image imIcon;

    Animator anim;

    public Animator instructionAnim;

    void Awake()
    {
        handMenuBtn.SetActive(false);
    }

    void Start() {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    public void CambiarFuncionalidad(object funcionalidad)
    {
        print("HandMenu en ... "+ funcionalidad);
        handMenuBtn.SetActive(true);
        
        switch (funcionalidad.ToString())
        {
            case "instruirAVivaVoz":
                imIcon.sprite = Resources.Load<Sprite>("Images/Icons/vivaVoz");
                handMenuBtn.GetComponent<BtnHandMenu>().iconActive = "Images/Icons/vivaVoz";
                break;
            case "hablarConSuboficial":
                imIcon.sprite = Resources.Load<Sprite>("Images/Icons/hablar");
                handMenuBtn.GetComponent<BtnHandMenu>().iconActive = "Images/Icons/hablar";
                break;
        }
    }

    public void CerrarPantalla()
    {
        screenMenuAnim.SetBool("close", true);
        handMenuBtn.GetComponent<BtnHandMenu>().activated = false;
        handMenuBtn.GetComponent<BtnHandMenu>().pTouched = false;
    }

    public void DesactivarBtn()
    {
        handMenuBtn.SetActive(false);
    }

    public void ShowInstructionAnim(object show)
    {
        if(show.ToString()=="true")
        {
            instructionAnim.SetBool("playHand", true);
        }
        else
        {
            instructionAnim.SetBool("playHand", false);
        }
    }
}
