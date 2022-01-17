using System;
using UnityEngine;

public class TriggerBridge : MonoBehaviour
{
	public event Action<Collider> TriggerEnter;
	public event Action<Collider> TriggerExit; 
	public event Action<Collider> TriggerStay; 

	void OnTriggerEnter(Collider other)
	{
		if (TriggerEnter != null)
			TriggerEnter(other);
	}

	void OnTriggerExit(Collider other)
	{
		if (TriggerExit != null)
			TriggerExit(other);
	}

	void OnTriggerStay(Collider other)
	{
		if (TriggerStay != null)
			TriggerStay(other);
	}
}
