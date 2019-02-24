using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrabAction : MonoBehaviour
{
    public abstract Transform DoAction(HandState state);
}
