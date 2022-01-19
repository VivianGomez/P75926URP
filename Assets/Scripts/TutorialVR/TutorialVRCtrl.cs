using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialVRCtrl : MonoBehaviour
{
    public OVRTouchSample.TouchController touchControllerLeft;
    public OVRTouchSample.TouchController touchControllerRight;


    public GameObject rightControlTutorial;
    public GameObject leftControlTutorial;
    public GameObject moveHandsHT;
    public GameObject menuUI;
    public GameObject tpTutorial;
    public GameObject handGesturesTutorial;
    public GameObject pressButtonTutorial;
    public GameObject palancasTutorial;
    public GameObject grabInstruction;
    public GameObject btnTutorial;
    public GameObject handMenuTutorial;
    public GameObject TP1;
    public GameObject TP2;
    public GameObject TP3;

    public GameObject interactions;
    public GameObject basePalancas;
    public GameObject botoneras;

    public GameObject grababbles;
    public GameObject selectOption;

    public AudioClip hologramSound;
    public AudioClip blopSound;
    public AudioClip tutorialGatillo;

    public AudioClip hideSound;

    public GameObject T1;
    public GameObject T2;
    public GameObject T3;


    void Start()
    {
        
    }

    public void ShowScreen(object show)
    {
        if(show.ToString()=="true")
        {
            gameObject.GetComponent<Animator>().SetBool("openScreen", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("openScreen", false);
        }
    }

    public void ShowInstruction(string instructionName)
    {
        AudioSource.PlayClipAtPoint(blopSound, Vector3.zero, 1.0f);
        switch (instructionName)
        {
            case "CameraRotation":
                rightControlTutorial.SetActive(true);
                leftControlTutorial.SetActive(false);
                touchControllerRight.ActiveThumstickController();
                touchControllerLeft.DisableThumstickController();
                break;

            case "MoveHandsHT":
                moveHandsHT.SetActive(true);
                break;

            case "CameraMovement":
                leftControlTutorial.SetActive(true);
                rightControlTutorial.SetActive(false);
                touchControllerLeft.ActiveThumstickController();
                touchControllerRight.DisableThumstickController();
                break;

            case "TPMovement":
                leftControlTutorial.SetActive(false);
                rightControlTutorial.SetActive(false);
                moveHandsHT.SetActive(false);
                tpTutorial.SetActive(true);

                if(touchControllerLeft!=null)
                {
                    touchControllerLeft.DisableThumstickController();
                    touchControllerRight.DisableThumstickController();
                    touchControllerRight.SetSecondaryButtonState("active");
                }
                
                break;

            case "handGestures":
                GameObject.Find("LeftControllerPf").SetActive(false);
                GameObject.Find("RightControllerPf").SetActive(false);

                leftControlTutorial.SetActive(false);
                rightControlTutorial.SetActive(false);
                tpTutorial.SetActive(false);
                handGesturesTutorial.SetActive(true);
                break;
            
            case "handMenu":
                grabInstruction.SetActive(false);
                grababbles.SetActive(false); 
                handMenuTutorial.SetActive(true);
                break;

            case "menuUI":
                grabInstruction.SetActive(false);
                grababbles.SetActive(false); 
                handMenuTutorial.SetActive(false);
                menuUI.SetActive(true);
                break;

            case "PressRedButton":
                leftControlTutorial.SetActive(false);
                rightControlTutorial.SetActive(false);
                tpTutorial.SetActive(false);
                handGesturesTutorial.SetActive(false);
                pressButtonTutorial.SetActive(true);   

                interactions.SetActive(true); 

                TP2.SetActive(true);
                TP2.GetComponent<Collider>().isTrigger=false;
                TP2.transform.localScale = new Vector3(TP2.transform.localScale.x, -0.00365f,TP2.transform.localScale.z);
                TP2.GetComponent<TPPointCtr>().active=true;
                TP2.GetComponent<TPPointCtr>().onceTime=true;

                break;

            case "ButtonsSequence":
                botoneras.SetActive(true); 
                GameObject.Find("BtnTutorialC").SetActive(false);   
                break;

            case "Palancas":
                pressButtonTutorial.SetActive(false);   
                palancasTutorial.SetActive(true);
                break;

            case "Grab":
                palancasTutorial.SetActive(false);
                grabInstruction.SetActive(true);
                break;
        }
    }

    public void DesactivarGrabbables()
    {
        grababbles.SetActive(false); 
        T1.SetActive(false); 
        T2.SetActive(false); 
        T3.SetActive(false); 
    }

    public void ActivarGrabbables()
    {
        grababbles.SetActive(true); 
    }

    public void ActivarTP1()
    {
        TP1.SetActive(true);
        TP1.GetComponent<Collider>().isTrigger=false;
        TP1.transform.localScale = new Vector3(TP1.transform.localScale.x, -0.00365f,TP1.transform.localScale.z);
        TP1.GetComponent<TPPointCtr>().active=true;
    }

    public void ActivarTP2()
    {
        TP2.SetActive(true);
        TP2.GetComponent<Collider>().isTrigger=false;
        TP2.transform.localScale = new Vector3(TP2.transform.localScale.x, -0.00365f,TP2.transform.localScale.z);
        TP2.GetComponent<TPPointCtr>().active=true;
    }

    public void ActivarTP3()
    {
        TP3.SetActive(true);
        TP3.GetComponent<Collider>().isTrigger=false;
        TP3.transform.localScale = new Vector3(TP3.transform.localScale.x, -0.00365f,TP3.transform.localScale.z);
        TP3.GetComponent<TPPointCtr>().active=true;
    }

    public void FinishTutorial()
    {
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            SceneManager.LoadScene("CuartoIngenieria");
        }
        else if(SceneManager.GetActiveScene().name == "TutorialHT")
        {
            SceneManager.LoadScene("CuartoIngenieriaHT");
        }
        
    }

    public void ActivarPalancas()
    {
        basePalancas.SetActive(true); 
    }

    public void ActivarMeshPalancas()
    {
        basePalancas.GetComponent<MeshRenderer>().enabled = true;
        basePalancas.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
        basePalancas.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
    }

    public void DesactivarPalancas()
    {
        basePalancas.GetComponent<Animator>().SetBool("disable", true);
    }

    public void ActivarBtnTutorial()
    {
        btnTutorial.SetActive(true); 
    }

    public void ActivarTutorialTrigger()
    {
        handMenuTutorial.SetActive(false);
        selectOption.SetActive(true); 
        //AudioSource.PlayClipAtPoint(tutorialGatillo, Vector3.zero, 1.0f);
        SimulatorController.Play("usarGatillo");
    }

    public void DesactivarBtnTutorial()
    {
        btnTutorial.SetActive(false); 
    }

    public void PlayHologramSound()
    {
        AudioSource.PlayClipAtPoint(hologramSound, Vector3.zero, 1.0f);
    }

    public void PlayHideSound()
    {
        AudioSource.PlayClipAtPoint(hideSound, Vector3.zero, 1.0f);
    }
}
