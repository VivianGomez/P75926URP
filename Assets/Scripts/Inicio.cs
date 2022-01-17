using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour
{
    bool selected = false;
    public void IrATutorial()
    {
        print("TUTO");
        if(!selected)
        {
            selected = true;
            StartCoroutine(ActivarTutorial());
        }
    }

    public IEnumerator ActivarTutorial()
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
        yield return new WaitForSeconds(4);
        if(SceneManager.GetActiveScene().name == "Inicio")
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if(SceneManager.GetActiveScene().name == "InicioHT")
        {
            SceneManager.LoadScene("TutorialHT");
        }
    }

    public void IrASimulacion()
    {
        print("SIMUL");
        if(!selected)
        {
            selected = true;
            StartCoroutine(ActivarSimulacion());
        }
    }

    public IEnumerator ActivarSimulacion()
    {
        GameObject.Find("CenterEyeAnchor").GetComponent<OVRScreenFade>().FadeOut();
        yield return new WaitForSeconds(4);
        if(SceneManager.GetActiveScene().name == "Inicio")
        {
            SceneManager.LoadScene("CuartoIngenieria");
        }
        else if(SceneManager.GetActiveScene().name == "InicioHT")
        {
            SceneManager.LoadScene("CuartoIngenieriaHT");
        }
    }

}
