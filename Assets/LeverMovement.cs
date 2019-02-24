using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMovement : MonoBehaviour
{

    public Transform entity;

    public LeverGrabAction left;
    public LeverGrabAction right;

    public LeverDetector leftDetector;
    public LeverDetector rightDetector;


    public float walkSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool leftD= leftDetector.fall_out_boy;
        bool rightD = rightDetector.fall_out_boy;

        if (leftD && rightD) {
            transform.position += new Vector3(Time.deltaTime * walkSpeed, 0, 0);
        } else if (leftD) {
            transform.rotation *= Quaternion.Euler(0, Time.deltaTime * rotationSpeed, 0);
        } else if (rightD) {
            transform.rotation *= Quaternion.Euler(0, -Time.deltaTime * rotationSpeed, 0);
        }
    }


    float CalculateRotation(Quaternion rightRot, Quaternion leftRot) {
        return rightRot.eulerAngles.x - leftRot.eulerAngles.x;
    }

    Vector2 CalculateMovement(Quaternion rightRot, Quaternion leftRot) {
        float rightX = rightRot.eulerAngles.x;
        float leftX = leftRot.eulerAngles.x;

        float forward = rightX + leftX;
        float strafe = rightRot.eulerAngles.z + leftRot.eulerAngles.z;

        print(forward);

        return new Vector2(strafe, forward);
    }


}
