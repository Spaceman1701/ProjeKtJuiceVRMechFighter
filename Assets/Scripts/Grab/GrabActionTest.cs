using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabActionTest : GrabAction
{
    public override Transform DoAction(HandState state)
    {
        Debug.Log("Doing action in GrabActionTest");
        state.Test();
        return null;
    }
}
