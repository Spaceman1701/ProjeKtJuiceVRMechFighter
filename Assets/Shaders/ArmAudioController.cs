using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ArmAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public float repeatTime;
    public float accelerationCutoff;

    public AudioSource source;

    private ArmTracker arm;

    private float timeSinceLastPlay;
    void Start()
    {
        timeSinceLastPlay = 0;
        arm = GetComponent<ArmTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arm.trackingEnabled) {
            Vector3 acceleration;
            OVRNodeStateProperties.GetNodeStatePropertyVector3(XRNode.LeftHand, NodeStatePropertyType.Acceleration, OVRPlugin.Node.HandLeft, OVRPlugin.Step.Render, out acceleration);
            if (acceleration.magnitude > accelerationCutoff) {
                if (timeSinceLastPlay > repeatTime) {
                    if (source.isPlaying) {
                        source.Stop();
                    }
                    source.Play();
                    timeSinceLastPlay = 0;
                }
            }
            timeSinceLastPlay += Time.deltaTime;
        }
    }
}
