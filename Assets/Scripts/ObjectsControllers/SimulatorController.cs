using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SimulatorController : MonoBehaviour
{
    public GameObject canvasFin;
    public GameObject indicadorAviso;

    void Start()
    {
        //MoverSuboficial("Suboficial1","PathIrArmarios");
    }

    public void MostrarFin()
    {
        canvasFin.SetActive(true);
    }

    public void FinalizarDemo()
    {
        SceneManager.LoadScene("FinDemo");
    }

    // aca podría cambiarlo por entregar guardia y que se vayan ejecutando las animaciones?
    public static int Play(object audioName)
    {
        return GuardiaVoice.PlayVoice(audioName.ToString());
    }

    public void MostrarRecordatorio(object audioName, object countdown, object objectoActivo)
    {
        GameObject.Find("Recordatorio").GetComponent<RecordatorioController>().MoverSobreObjeto(objectoActivo.ToString().Trim());
        if(audioName.ToString() != ""){GuardiaVoice.PlayVoice(audioName.ToString());}
    }

    public int Esperar(object time)
    {
        return Convert.ToInt32(time)*1000;
    }

    public async void MoverSuboficial(string nombreSub, string nombrePath)
    {
        MoveCharWithAnimation moveChar = GameObject.Find(nombreSub).transform.GetChild(0).gameObject.GetComponent<MoveCharWithAnimation>();
        moveChar.setPathBase(GameObject.Find(nombrePath));
        await moveChar.StartMove();
    }

    public void Reubicar(string nombreSub, object x, object y, object z)
    {
        GameObject.Find(nombreSub).transform.position= new Vector3(float.Parse(""+x), float.Parse(""+y), float.Parse(""+z));
    }

    public void InicializarConstantes(string dirAudio)
    {
        MOBController.currentDirectoryAudios = dirAudio;
    }


    public void MostrarIndicadorAviso(object mostrar)
    {
        if(mostrar.ToString()=="true")
        {
            indicadorAviso.SetActive(true);
        }
        else if(mostrar.ToString()=="false")
        {
            indicadorAviso.SetActive(false);
        }
    }
}
