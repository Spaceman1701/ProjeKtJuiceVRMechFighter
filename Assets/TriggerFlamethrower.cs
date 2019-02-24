using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class TriggerFlamethrower : MonoBehaviour
{
    // Start is called before the first frame update
    public float threshold;
    public float trigger;
    private ParticleSystem flamethrower;
    void Start()
    {
        flamethrower = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        trigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        var emission = flamethrower.emission;
        if (trigger > threshold) {
            emission.enabled = true;
        } else {
            emission.enabled = false;
        }
    }
}
