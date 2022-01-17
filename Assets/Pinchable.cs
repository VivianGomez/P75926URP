using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchable : MonoBehaviour
{
	/// <summary>
	/// Fired whenever the Pinchable gets pinched.
	/// Parameters: sender, detector
	/// </summary>
	public event Action<Pinchable, PinchDetector> StartPinching;

	public event Action<Pinchable, PinchDetector> StopPinching;

	public event Action<Pinchable, PinchDetector> ExitPinching;

	private void Start() {
		
	}

	public bool IsPinching
	{
		get;
		private set;
	}

	public void StartPinch(PinchDetector sender)
	{
		IsPinching = true;

		if (StartPinching != null)
			StartPinching(this, sender);
	}

	public void StopPinch(PinchDetector sender)
	{
		IsPinching = false;

		if (StopPinching != null)
			StopPinching(this, sender);
	}

	public void ExitPinch(PinchDetector sender)
	{
		if (ExitPinching != null)
			ExitPinching(this, sender);
	}
}
