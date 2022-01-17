using System.Threading.Tasks;
using UnityEngine;
using System;


public class Suboficial : MonoBehaviour
{
    public GameObject telCabeza;
    public GameObject telCabeza2;
    public GameObject telCabezaM;

    Animator anim;
    
    GameObject playerObject;
    public bool lookat=true;


    // Update is called once per frame
    void Update()
    {
        if(lookat)
        {
            gameObject.transform.LookAt(playerObject.transform, Vector3.zero);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        }
    }

    void Start() 
    {
        anim = gameObject.GetComponent<Animator>();
        playerObject = GameObject.Find("CenterEyeAnchor");
    }

    public void PlayFootstepSound()
    {
        GetComponent<AudioSource>().Play();
    }
    
    public int PlayAnimation(object animationName)
    {
        print("playing... "+ animationName);
        anim.SetBool("open", false);
        anim.SetBool("close", false);
        anim.SetBool("give", false);
        anim.SetBool("bajarbrazo", false);
        anim.SetBool("bajaragarrar", false);
        anim.SetBool("grab", false);
        anim.SetBool("salute", false);
        anim.SetBool("ponersetelefono", false);

        int delay = 0;
        
        switch (animationName)
        {
            case "AbrirPuerta":
                anim.SetBool("open", true);
                break;
            case "CerrarPuerta":
                anim.SetBool("close", true);
                break;
            case "TomarTelefono":
                anim.SetBool("grab", true);
                break;
            case "PonerseTelCabeza":
                anim.SetBool("ponersetelefono", true);
                break;
            case "EntregarTelefono":
                anim.SetBool("give", true);
                break;
            case "RecibirTelefono":
                anim.SetBool("give", true);
                break;
            case "BajarAgarrar":
                anim.SetBool("bajaragarrar", true);
                break;
            case "BajarEntregar":
                anim.SetBool("bajarbrazo", true);
                break;
            case "SaludoOficial":
                anim.SetBool("salute", true);
                break;
            case "HablarTelefono":
                anim.SetBool("talking", true);
                break;
            case "Idle":
                anim.SetBool("talking", false);
                anim.SetBool("open", false);
                anim.SetBool("close", false);
                anim.SetBool("bajarbrazo", false);
                anim.SetBool("bajaragarrar", false);
                anim.SetBool("grab", false);
                anim.SetBool("ponersetelefono", false);
                anim.SetBool("give", false);

                delay = 500;
                break;
        }

        if(animationName.ToString() != "Idle")
        {
            //delay = (int.Parse(""+ Convert.ToInt32(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length*1000)));
            delay = (int.Parse(""+ Convert.ToInt32(DarTiempoClip(animationName.ToString())*1000)));
        }
        
        return delay;
    }

    public float DarTiempoClip(string clipName)
    {
        float delay = 0;
        switch (clipName)
        {
            case "AbrirPuerta":
                delay = 5;
                break;
            case "CerrarPuerta":
                delay = 2.5f;
                break;
            case "TomarTelefono":
                delay = 4.50f;
                break;
            case "PonerseTelCabeza":
                delay = 3.5f;
                break;
            case "EntregarTelefono":
                delay = 1;
                break;
            case "RecibirTelefono":
                delay = 1;
                break;
            case "BajarAgarrar":
                delay = 1.18f;
                break;
            case "BajarEntregar":
                delay = 1.7f;
                break;
            case "SaludoOficial":
                delay = 2.83f;
                break;
             case "HablarTelefono":
                delay = 4.55f;
                break;
            case "Idle":
                delay = 1;
                break;
        }

        return delay;
    }

    public void EntregarTelefono()
    {
        telCabezaM.SetActive(false);
    }

    public void MostrarTelefono(object mostrar)
    {
        if(mostrar.ToString()=="true")
        {
            telCabeza.SetActive(true);
        } 
        else 
        {
            telCabeza.SetActive(false);
        }
    }

    public void TomarTelefonos()
    {
        telCabeza.SetActive(true);
        //telCabezaM.SetActive(true);
        Destroy(GameObject.Find("TelCabGrab"));
    }

    public void UsarTelCabeza()
    {
        telCabeza2.SetActive(true);
    }

    public void MirarJugador(object mirar)
    {
        if(mirar.ToString()=="true")
        {
             lookat=true;
        } 
        else 
        {
            lookat=false;
        }
    }
}
