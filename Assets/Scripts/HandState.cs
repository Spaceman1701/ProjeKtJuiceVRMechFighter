using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandState 
{
    public Transform transform;   
    public float indexPress = 0;
    public float triggerPress = 0;

    public float GetIndexPress()
    {
        return indexPress;
    }

    public float GetTriggerPress()
    {
        return triggerPress;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Test()
    {
        Debug.Log("Called from HandState");
    }
}
