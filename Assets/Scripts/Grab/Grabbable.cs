using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrabAction), typeof(Collider), typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    private GrabAction grabAction;
    private Grabber grabbedBy = null;

    // Start is called before the first frame update
    void Start()
    {
        grabAction = GetComponent<GrabAction>();
    }

    public void DoGrabAction(HandState handState)
    {
        Transform change = grabAction.DoAction(handState);
        transform.position = change.position; // Might want to make this a gradual change
        transform.rotation = change.rotation;
    }

    public bool isGrabbed()
    {
        return (grabbedBy != null); 
    }

    public void EndGrab()
    {
        grabAction.OnEndGrab(grabbedBy.handState);
        grabbedBy = null;
    }

    public void BeginGrab(Grabber grabber)
    {
        grabbedBy = grabber;
        grabAction.OnBeginGrab(grabber.handState);
    }
}
