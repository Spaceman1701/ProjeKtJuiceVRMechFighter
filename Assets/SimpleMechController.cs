using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using UnityEngine.XR;

public class SimpleMechController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        OVRInput.Update();

        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Vector3 position = transform.position;
        position.z += input.y * moveSpeed;
        position.x += input.x * moveSpeed;

        transform.position = position;


        Vector2 rotInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        transform.Rotate(new Vector3(0, rotInput.x, 0), Space.World);
        
    }

    void FixedUpdate() {
        
        OVRInput.FixedUpdate();
    }
}
