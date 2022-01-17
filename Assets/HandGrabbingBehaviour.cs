using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabbingBehaviour : OVRGrabber
{
    private OVRHand m_hand;
    public float pinchThreshold = 0.5f;

    public bool grabGesture = false;
    
    protected override void Start() {
        
        base.Start();
        m_hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
    }

    public void ChangeGrabGestureState(bool state)
    {
        grabGesture = state;
    }

    void CheckIndexPinch()
    {
        float pinchStrenght = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        if(!m_grabbedObj && (pinchStrenght > pinchThreshold) && m_grabCandidates.Count > 0)
        {
            GrabBegin();
        }
        else if( m_grabbedObj && ! (pinchStrenght > pinchThreshold))
        {
            GrabEnd();
        }
    }
}
