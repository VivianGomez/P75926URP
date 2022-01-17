using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static MOBObject;

public class MenuSuboficialController : MonoBehaviour
{
    public GameObject menuObject;
    void Start()
    {
        menuObject.SetActive(false);
    }
    public void ActivarMenu()
    {
        menuObject.SetActive(true);
    }
    public async void SeleccionarOpcion(string opcion)
    {
        RecordatorioController.OcultarRecordatorio();

        if(opcion == "IrACuartoMaquinas")
        {
            //Suboficial.IrCuartoDeMaquinas()
            //Cambiarlo por la animación de ir hacia el cuarto de máquinas
            gameObject.transform.parent.gameObject.SetActive(false);
            await Task.Delay(5000);
            print("Wait --- Suboficial.IrCuartoDeMaquinas()");
            //
        }

        GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new Action(gameObject.name, "SeleccionarOpcion",opcion));
    }
}
