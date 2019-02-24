using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandState 
{
    public Transform transform;   
    public float indexPress = 0;
    
    public float GetIndexPress()
    {
        return indexPress;
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
