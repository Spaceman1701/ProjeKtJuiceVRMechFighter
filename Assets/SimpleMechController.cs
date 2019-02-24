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
        if(OVRInput.IsControllerConnected(OVRInput.Controller.LTouch)) {
            Debug.Log("ltouch connected");
        }
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Debug.Log(input);
        Vector3 position = transform.position;
        position.z += input.y * moveSpeed;
        position.x += input.x * moveSpeed;

        transform.position = position;
        
    }

    void FixedUpdate() {
        
        OVRInput.FixedUpdate();
    }
}
