﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRArmIK;

public class ArmTracker : MonoBehaviour
{

    public GameObject unscaledAnchor;
    public ArmTransforms ikReferenceArm;
    public Transform ikReferenceShoulders;

    public Transform shoulder;
    public Transform upperArm;
    public Transform lowerArm;
    public Transform hand;

    public Transform shoulderJoint;
    public Transform shoulderAnchor;
    public Transform upperElbowJoint;
    public Transform lowerElbowJoint;
    public Transform wristJoint;

    public bool trackingEnabled;


    // Start is called before the first frame update
    void Start()
    {
        ikReferenceArm = unscaledAnchor.GetComponentInChildren<ArmTransforms>();
        ikReferenceShoulders = unscaledAnchor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trackingEnabled) {
            return;
        }
        Quaternion upperArmRot = ikReferenceArm.upperArm.localRotation;
        Quaternion lowerArmRot = ikReferenceArm.lowerArm.localRotation;
        Quaternion handRot = ikReferenceArm.hand.localRotation;
        
        shoulder.localRotation = ikReferenceShoulders.localRotation;
        upperArm.localRotation = upperArmRot;
        lowerArm.localRotation = lowerArmRot;
        hand.localRotation = handRot;

        lowerArm.Translate(GetElbowJointDistance(), Space.World);
        upperArm.Translate(GetShoulderJointDistance(), Space.World);
    }

    private Vector3 GetElbowJointDistance() {
         return upperElbowJoint.position - lowerElbowJoint.position;
    }

    private Vector3 GetShoulderJointDistance() {
        return shoulderAnchor.position - shoulderJoint.position;
    }

    public void SetTrackingEnabled(bool newValue) {
        this.trackingEnabled = newValue;
    }

}
