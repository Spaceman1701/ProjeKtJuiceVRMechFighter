using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGrabbable : GrabAction
{

    public ArmTracker arm;
    public AudioSource armAudio;
    public Transform returnAnchor;
    public float deadTime;
    public float zipTime;
    private bool isBeingGrabbed;
    private float timeUntilAlive;
    private float timeSinceReleased;


    // Start is called before the first frame update
    void Start()
    {
        arm.SetTrackingEnabled(false);
        timeSinceReleased = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingGrabbed) {
            if (timeUntilAlive <= 0) {
                arm.SetTrackingEnabled(true);
            } else {
                timeUntilAlive -= Time.deltaTime;
            }
        }  else {
            ZipBackToStart();
            timeSinceReleased += Time.deltaTime;
            arm.SetTrackingEnabled(false);
        }
    }

    public void ZipBackToStart() {
        if ((transform.position - returnAnchor.position).magnitude > 0.05) {
            transform.rotation = Quaternion.Lerp(transform.rotation, returnAnchor.rotation, timeSinceReleased / zipTime);
            transform.position = Vector3.Lerp(transform.position, returnAnchor.position, timeSinceReleased / zipTime);
        }
    }

    public override Transform DoAction(HandState state) {
        return state.GetTransform();
    }

    public override void OnBeginGrab(HandState state) {
        armAudio.Play();
        timeSinceReleased = 0;
        timeUntilAlive = deadTime;
        isBeingGrabbed = true;
    }

    public override void OnEndGrab(HandState state) {
        isBeingGrabbed = false;
    }
}
