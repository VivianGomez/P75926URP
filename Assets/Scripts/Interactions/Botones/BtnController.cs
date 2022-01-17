using System;
using System.Collections;
using UnityEngine;

public class BtnController : OutlineManager
{
    // Animación y sonido
    public string typeInteraction = "pressed";
    public AudioClip soundDownEnabled;
    public AudioClip soundDownDisabled;
    private Animator anim;


    // Control de activación 
    public bool activated = false;
    public bool pTouched = false;

    // Cambio de propiedades del material del botón
    private Renderer rendererComp;
    private Material defaultMat;

    // Cambio de propiedades del material de la caja del botón
    private Renderer cajaRender;
    private GameObject cajaBoton;


    void Start()
    {
        Outline.enabled = false;
        ObjectiveColor = new Vector4(0.145098f, 0.7176471f, 1f, 1f);
        Initialize();
    }

    public void Initialize()
    {
        rendererComp = GetComponent<Renderer>();
        defaultMat = rendererComp.material;
   
        pTouched = false;
        anim = GetComponent<Animator>();

        cajaBoton = gameObject.transform.parent.gameObject;
        cajaRender = cajaBoton.GetComponent<Renderer>();
    }

    public void ActiveAnimation()
    {
        activated = !activated;
        anim.SetBool(typeInteraction, activated);

        if (activated)
        {
            AudioSource.PlayClipAtPoint(soundDownEnabled, Vector3.zero, 1.0f);
            if (gameObject.tag == "BtnBlanco")
            {
                Color yColor = new Vector4(0.9811321f, 0.9691382f, 0.5692418f, 1f);
                rendererComp.material.SetColor("_Color", yColor);
            }
            rendererComp.material.SetFloat("_Metallic", .0f);
            rendererComp.material.SetFloat("_Glossiness", .0f);

            // Outline botón
            ShowSuccessColor();
        }
        else
        {
            AudioSource.PlayClipAtPoint(soundDownDisabled, Vector3.zero, 1.0f);
            rendererComp.material.SetColor("_Color", Color.white);
            rendererComp.material.SetFloat("_Metallic", .53f);
            rendererComp.material.SetFloat("_Glossiness", .55f);

            // Outline botón
            DisableOutline();
        }
    }

    protected virtual void Touched()
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

    void OnMouseDown()
    {
        Touched();
    }
}
