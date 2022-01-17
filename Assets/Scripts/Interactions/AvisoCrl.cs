using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoCrl : MonoBehaviour
{
    bool enConsola = false;
	private PinchDetector currentPinchingHand = null;
	private Pinchable pinchable = null;

    void Awake()
    {
		//pinchable = GetComponent<Pinchable>();

		//pinchable.StartPinching += OnStartPinching;
		//pinchable.StopPinching += OnStopPinching;
    }
    public void PonerEnConsola()
    {
        GameObject.Find("MOBController").GetComponent<MOBController>().VerifyUserAction(new MOBObject.Action(gameObject.name, "PonerEnConsola",""));
    }

    void OnTriggerEnter(Collider other)
    {
        if(!enConsola && other.gameObject.name =="TabPanelPropulsion")
        {
            PonerEnConsola();
            enConsola = true;
        }
    }


    /**
    private void OnStopPinching(Pinchable sender, PinchDetector pinchingHand)
	{
		gameObject.GetComponent<Rigidbody>().isKinematic = false;
	}

	private void OnStartPinching(Pinchable sender, PinchDetector pinchingHand)
	{
		transform.position = pinchingHand.GrabVolume.transform.position;
        transform.rotation = pinchingHand.transform.parent.rotation;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
	}**/

}
