
using UnityEngine;
using System;
using TMPro;

public class PntAlarmasController : MonoBehaviour
{
    public TextMeshProUGUI txtNombreAlarma;
    public TextMeshProUGUI txtTiempoAlarma;
    public TextMeshProUGUI txtHoraPnt;

    public Renderer rendererAMS;
    public Material ams;
    public Material alarmas;


    public GameObject pantallaAlarmas;
    public GameObject pantallaHome;
    public GameObject avisoAlarma;

    private void Start()
    {
        txtNombreAlarma.text = "...";
        if(avisoAlarma!=null)
        {
            avisoAlarma.SetActive(false);
            pantallaAlarmas.SetActive(false);
            pantallaHome.SetActive(true);
            rendererAMS.material = ams;
        }
        
    }

    void Update() {
        txtHoraPnt.text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void ActivarAlama(object estado, object sensor)
    {
        txtNombreAlarma.text = sensor.ToString()+" - "+ estado.ToString();
        SoundManager.PlaySound("alarma");
    }

    public void ActualizarValorSensor(object sensor, object valor)
    {
        txtNombreAlarma.text = sensor.ToString()+" = "+ valor.ToString();
        SoundManager.PlaySound("alarma");
    }

    public void ActivarAlarmaAMS(object alarma)
    {
        txtNombreAlarma.text = alarma.ToString();
        txtTiempoAlarma.text = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") + " - 01m - Aux";
        GameObject.Find("AlarmAveria").GetComponent<Animator>().SetBool("activarAlarma", true);
        avisoAlarma.SetActive(true);
        avisoAlarma.GetComponent<Animator>().SetBool("activarAlarma", true);
    }

    public void MostrarAlarmas()
    {
        avisoAlarma.GetComponent<Animator>().SetBool("activarAlarma", false);
        pantallaAlarmas.SetActive(true);
        pantallaHome.SetActive(false);
        GameObject.Find("ItemAMS").GetComponent<Animator>().SetBool("activarAlarma", true);
        rendererAMS.material = alarmas;
    }

    public void AceptarAlarma()
    {
        GameObject alarmAveria = GameObject.Find("AlarmAveria");
        alarmAveria.GetComponent<AlarmasCMCtrl>().DesactivarAlarmaCM();
        alarmAveria.GetComponent<Animator>().SetBool("activarAlarma", false);
        avisoAlarma.SetActive(false);
        GameObject.Find("ItemAMS").GetComponent<Animator>().SetBool("activarAlarma", false);
    }
    
}
