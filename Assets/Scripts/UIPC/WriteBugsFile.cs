using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class WriteBugsFile : MonoBehaviour
{
    public int contador;

    public TMP_Text txtInput;

    MOBController mobController;
    BugTracker bugTracking;

    void Awake()
    {
        mobController = GameObject.Find("MOBController").GetComponent<MOBController>();
        bugTracking = GameObject.Find("BugTracking").GetComponent<BugTracker>();
    }

    public void ImprimirComentario()
    {
        WriteString(txtInput.text);
        print(txtInput.text);
        gameObject.SetActive(false);
        bugTracking.Caller();
        Destroy(gameObject);
    }

    public void Close()
    {
        Destroy(gameObject);
    }
    public void WriteString(string texto)
    {
        string path = Application.dataPath + "/Resources/BugTracker/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("N"+contador+" - "+System.DateTime.Now.ToString("HH:mm:ss")+ "--> COMENTARIO: " + texto + " EN EL MOMENTO: " + IdentificarMomentoSimulacion());
        writer.Close();
    }

    public string IdentificarMomentoSimulacion()
    {
        return mobController.GetCurrentNode().title;
    }
}
