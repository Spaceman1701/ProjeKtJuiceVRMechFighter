using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Grabber : MonoBehaviour
{
    private Grabbable grabbedObject = null;
    private bool hasGrabbedObject = false;
    public HandState handState;
    private Collider volume; // Collider of hand set by component 
    
    // Set boundaries for a "grab"
    public float grabMin = 0.55f;

    private List<Grabbable> grabCandidates = new List<Grabbable>();

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Collider>();
        volume.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbedObject != null)
        {
            grabbedObject.DoGrabAction(handState);
        }

        float triggerPress = handState.GetIndexPress();
        GrabOrRelease(triggerPress);

    }

    private void GrabOrRelease(float pressVal)
    {
        // If trigger is pushed enough to grab the object
        if (pressVal >= grabMin)
        {
            Debug.Log("Pressure: " + pressVal);
            BeginGrab();
        }
        else
        {
            EndGrab();
        }
        
    }

    private void BeginGrab()
    {
        if (hasGrabbedObject)
        {
            return;
        }
        Debug.Log("Beginning grab in Grabber");

        Vector3 currentPos = transform.position;
        float closest = float.MaxValue;
        foreach(Grabbable potentialGrabbed in grabCandidates){
            if (!potentialGrabbed.isGrabbed())
            {
                float dist = Vector3.Distance(currentPos, potentialGrabbed.transform.position);
                if (dist < closest)
                {
                    grabbedObject = potentialGrabbed;
                }
            }
        }

        // If there is an object nearby
        if (grabbedObject != null)
        {
            hasGrabbedObject = true;
            grabbedObject.BeginGrab(this);
        }
    }

    private void EndGrab()
    {
        if (grabbedObject == null)
        {
            return;
        }
        Debug.Log("Ending Grab in grabber");

        grabbedObject.EndGrab(); // Here is where physics stuff would happen
        hasGrabbedObject = false;
        grabbedObject = null;
    }

    // Called when the collider hits another collider
    public void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("Triggered");
        // Try and get the Grabbable component in the other Collider or the other Collider's parent.
        Grabbable grabObject = otherCollider.GetComponent<Grabbable>() ?? otherCollider.GetComponentInParent<Grabbable>();
        if (grabObject == null)
        {
            return;
        }
        if (!grabCandidates.Contains(grabObject))
        {
            grabCandidates.Add(grabObject);
            Debug.Log("Adding GrabObject to list");
        }
    }

    public void OnTriggerExit(Collider otherCollider)
    {
        Grabbable grabObject = otherCollider.GetComponent<Grabbable>() ?? otherCollider.GetComponentInParent<Grabbable>();
        Debug.Log("Exit Triggered");
        if (grabCandidates.Contains(grabObject))
        {
            grabCandidates.Remove(grabObject);
            Debug.Log("Removing GrabObject from list");
        }

        if (grabObject == grabbedObject)
        {
            EndGrab();
        }
    }
}
