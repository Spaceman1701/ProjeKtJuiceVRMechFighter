using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandState : MonoBehaviour
{
    public float indexPress = 0;

    public OVRInput.Controller controller;
    
    public float GetIndexPress()
    {
        return indexPress;
    }

    public float GetTriggerPress()
    {
        return 0;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Update() {
        indexPress =  OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
    }

    public void Test()
    {
        Debug.Log("Called from HandState");
    }
}
