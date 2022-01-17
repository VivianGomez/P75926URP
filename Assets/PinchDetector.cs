using UnityEngine;
using System.Collections.Generic;

public class PinchDetector : MonoBehaviour
{
	private const float PINCHING_THRESHOLD = 0.1f;

    [SerializeField]
    private OVRHand _hand;

	
	public GameObject GrabVolume;

	private TriggerBridge grabVolumeTriggerBridge;

	private void Start() {
		
	}

	public bool IsPinching
	{
		get;
		private set;
	}

	void Awake()
	{
        IsPinching = false;
		grabVolumeTriggerBridge = GrabVolume.AddComponent<TriggerBridge>();

		//grabVolumeTriggerBridge.TriggerEnter += OnTriggerBridgeEnter;
		grabVolumeTriggerBridge.TriggerStay += OnTriggerBridgeStay;
		grabVolumeTriggerBridge.TriggerExit += OnTriggerBridgeExit;
	}

	private void OnTriggerBridgeExit(Collider other)
	{
		Pinchable collidedPinchable = other.GetComponentInParent<Pinchable>();
		if (collidedPinchable != null)
		{
			collidedPinchable.ExitPinch(this);
			collidedPinchable.StopPinch(this);
		}
	}

    private void OnTriggerBridgeStay(Collider other)
	{
		if (other.tag=="Pinchable")
        {
			other.GetComponentInParent<Pinchable>().StartPinch(this);
        }
	}

	
}