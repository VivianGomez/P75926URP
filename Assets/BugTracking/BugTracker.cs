using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BugTracker : MonoBehaviour
{
    public GameObject cuadroTexto;
    public static int contador=0;
    // Update is called once per frame

    public GameObject player;

    public float spawnDistance;

    void Start()
    {
        string path = Application.dataPath + "/Resources/BugTracker/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("\n *************** REGISTRO DE COMENTARIOS ("+System.DateTime.Now.ToString("yyyy'-'MM'-'dd")+") ***************");
        writer.Close();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            if(GameObject.Find("BTDialog(Clone)")==null)
            {
                contador++;
                //Caller();

                Vector3 playerPos = player.transform.position;
                Vector3 playerDirection = player.transform.forward;
                Quaternion playerRotation = player.transform.GetChild(0).transform.rotation;
                Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
    
                GameObject cuadro = Instantiate(cuadroTexto, spawnPos, playerRotation);
                cuadro.GetComponent<Canvas>().worldCamera = player.transform.GetChild(0).GetComponent<Camera>();
                cuadro.GetComponent<WriteBugsFile>().contador = contador;
            }
        }
    }

    public void Caller()
    {
        print("SE ESTA REPORTANDO UN BUG");
        string imagePath =  Application.dataPath + "/Resources/BugTracker/BUG-N"+contador+"-"+System.DateTime.Now.ToString("yyyy'-'MM'-'dd'TIME'HH'-'mm'-'ss")+".png";
        StartCoroutine(Screenshot(imagePath));  
    }


    IEnumerator Screenshot(string imagePath)
    {
        yield return new WaitForEndOfFrame();
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);

        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        
        byte[] imageBytes = screenImage.EncodeToPNG();

        System.IO.File.WriteAllBytes(imagePath, imageBytes);

    }
}
