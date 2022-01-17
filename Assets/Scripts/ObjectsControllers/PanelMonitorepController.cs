using System.Collections;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PanelMonitorepController : MonoBehaviour
{
    [SerializeField] public Transform parentOfResponses;
    [SerializeField] public Transform prefab_btnResponse;
    public TextMeshProUGUI txtMotorActual;

    public TextMeshProUGUI txtTempAceite;
    public TextMeshProUGUI txtTempAgua;
    public TextMeshProUGUI txtHoraPnt;

    public Renderer rendererPanelMonitoreo;
    public Material antesDeAsegurar;
    public Material despuesDeAsegurar;

    public bool viewing = false;

    bool tempDown = false;
    bool completeTempView = false;
    bool propulsorAsegurado = true;

    void Start()
    {
        KillAllChildren(parentOfResponses);
        txtMotorActual.text = "Propulsor Estribor";
        CambiarEstadoPantalla();
    }

    void Update() {
        txtHoraPnt.text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void CambiarEstadoPantalla()
    {
        propulsorAsegurado = !propulsorAsegurado;

        if(propulsorAsegurado)
        {
            rendererPanelMonitoreo.material = despuesDeAsegurar;
            ActualizarValorIndicador("tempAceite","28.4");
            ActualizarValorIndicador("tempAgua","30");
        }
        else
        {
            rendererPanelMonitoreo.material = antesDeAsegurar;
            ActualizarValorIndicador("tempAceite","49");
            ActualizarValorIndicador("tempAgua","58");
        }
    }

    public static void KillAllChildren(UnityEngine.Transform parent)
    {
        UnityEngine.Assertions.Assert.IsNotNull(parent);
        for (int childIndex = parent.childCount - 1; childIndex >= 0; childIndex--)
        {
            UnityEngine.Object.DestroyImmediate(parent.GetChild(childIndex).gameObject);
        }
    }

    public void ActualizarValorIndicador(object sensor, object valor)
    {
        SoundManager.PlaySound("alarma");

        switch ( sensor.ToString() ) {
			case "tempAceite": txtTempAceite.text = valor.ToString()+" °C";; break;
			case "tempAgua": txtTempAgua.text = valor.ToString()+" °C";; break;
		}

        tempDown = true;
    }

    public void ActivarAlama(object estado, object sensor)
    {
        SoundManager.PlaySound("alarma");
        var responceButton = Instantiate(prefab_btnResponse, parentOfResponses);
        responceButton.GetComponentInChildren<TextMeshProUGUI>().text = sensor.ToString()+" = "+ estado.ToString();
    }

    public void ActualizarValorSensor(object sensor, object valor)
    {
        SoundManager.PlaySound("alarma");
        var responceButton = Instantiate(prefab_btnResponse, parentOfResponses);
        responceButton.GetComponentInChildren<TextMeshProUGUI>().text = sensor.ToString()+" = "+ valor.ToString();
    }

    public async void Viewed()
    {
        if(!completeTempView && viewing)
        {
            bool r = await GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "Viewed",""));
            if(r) {completeTempView=true;}
        } 
    }


    void OnTriggerStay(Collider other)
    {
        if(!completeTempView && tempDown && other.gameObject.name=="CenterEyeAnchor")
        {
            Viewed();
            viewing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name=="CenterEyeAnchor")
        {
            viewing = false;
        }
    }
}
