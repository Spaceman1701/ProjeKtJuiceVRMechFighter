﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandState 
{
    public Vector3 position;
    public float indexPress = 0;
    
    public float GetIndexPress()
    {
        return indexPress;
    }

    public void Test()
    {
        Debug.Log("Called from HandState");
    }
}