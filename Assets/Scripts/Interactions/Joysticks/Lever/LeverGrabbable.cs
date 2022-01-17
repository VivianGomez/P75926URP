using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;

public class LeverGrabbable : OVRGrabbable
{
    public Transform handler;
    public PlcVelController lever;

    public object expectedValue = null;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;

        Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
        rbhandler.velocity = Vector3.zero;
        rbhandler.angularVelocity = Vector3.zero;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update() 
    {
        if(Vector3.Distance(handler.position, transform.position) > 0.0225f)
        {
            //grabbedBy.ForceRelease(this);
            GrabEnd(Vector3.zero, Vector3.zero);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if((other.tag == "Fingers" || other.tag == "IndexFinger") && !lever.IsSuccessfullyCompleted)
        {
            lever.ShowInteractingcolor();
            string ladoMotor = lever.name.Substring(lever.name.Length - 3);
            //print("EL VALOR ACTUAL ES = "+(lever.GetCurrentValue()));
            GameObject.Find("ManPitch"+ladoMotor).GetComponent<ManPitchController>().MoverHasta(lever.GetCurrentValue());
        }
    }

    public void SetExpectedValue(object newVal)
    {
        expectedValue = newVal;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Fingers" || other.tag == "IndexFinger")
        {
            if(SceneManager.GetActiveScene().name.StartsWith("Tutorial"))
            {
                if(expectedValue!= null && lever.IsGreenSection())
                {
                    print("** Finalizó la interacción exitosamente **");
                    GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(lever.name, "EsVerde",""));
                    expectedValue = null;
                    lever.CompleteInteraction(true);
                }
            }
            else
            {
                if(expectedValue!= null && lever.CompareCurrentValWith(float.Parse(expectedValue.ToString())))
                {
                    print("** Finalizó la interacción exitosamente **");
                    GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(lever.name, "ConfirmarNudos",expectedValue.ToString()));
                    //task.Wait();
                    expectedValue = null;
                    lever.CompleteInteraction(true);
                }
            }
            lever.DisableOutlineLever();
        }
    }
}
