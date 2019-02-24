using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrabAction : MonoBehaviour
{
    public abstract Transform DoAction(HandState state);

    public virtual void OnBeginGrab(HandState state) {

    }

    public virtual void OnEndGrab(HandState state) {
        
    }
}
