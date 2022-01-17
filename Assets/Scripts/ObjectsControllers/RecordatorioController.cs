using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordatorioController : MonoBehaviour
{
    static GameObject recordatorio;
    void Start()
    {
        recordatorio = gameObject;
    }
    public void MoverSobreObjeto(string obj)
    {
        GameObject objeto = GameObject.Find(obj);
        var x = objeto.transform.position.x;
        var y = objeto.transform.position.y;
        var z = objeto.transform.position.z;

        recordatorio.transform.position= new Vector3(x, y+0.3f, z);

        if(objeto.GetComponent<OutlineManager>()!=null)
        {
            print("Tiene OutlineManager");
            OutlineManager outline = objeto.GetComponent<OutlineManager>();
            outline.ShowObjectiveColor();
        }
        else if(GetParentObject(objeto).GetComponent<OutlineManager>()!=null)
        {
            //Este caso en particular lo usamos para el objeto HandlerPlcVel
            print("El padre tiene OutlineManager");
            OutlineManager outline = GetParentObject(objeto).GetComponent<OutlineManager>();
            outline.ShowObjectiveColor();
        }
    }

    public static void OcultarRecordatorio()
    {
        if(recordatorio!=null)
            recordatorio.transform.position= new Vector3(-2.37f, 1.551f, -0.341f);
    }

    public GameObject GetParentObject(GameObject objeto)
    {
        GameObject parent = objeto;
        if(objeto.transform.parent!=null)
        {
            parent = objeto.transform.parent.gameObject;
        }
        
        return parent;
    }
}
