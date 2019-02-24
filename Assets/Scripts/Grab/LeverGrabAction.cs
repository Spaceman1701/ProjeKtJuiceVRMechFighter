using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGrabAction : GrabAction
{
    public Transform anchorPoint;
    public Transform leverBottom;
    public Transform lever;

    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = false;

    public override Transform DoAction(HandState handState)
    {
        Transform newTransform = lever;
        Vector3 positionDiff = lever.position - handState.GetTransform().position;

/*        Debug.Log("Lever Postion: " + lever.position);
        Debug.Log("Hand position: " + handState.GetTransform().position);
        Debug.Log("Position difference: " + positionDiff);*/
        // Make line of sight quanternian 
        Quaternion fullRotation = Quaternion.LookRotation(positionDiff, Vector3.up);

        //Debug.Log("Full rotation quaternion: " + fullRotation.eulerAngles);
        Vector3 newAngles = newTransform.eulerAngles;
        //Debug.Log("New Angles Before Update: " + newAngles);
        //Debug.Log("diffy" + (Mathf.Abs(fullRotation.eulerAngles.y - newAngles.y)-180));

        newAngles.x = fullRotation.eulerAngles.x - 90;
        newAngles.y = fullRotation.eulerAngles.y;
        /*if (Mathf.Abs(newTransform.rotation.y - fullRotation.eulerAngles.y-180) < 1)
        {
            Debug.Log("Switching angles sign from " + newAngles.x);
            newAngles.x = -newAngles.x;
        }*/
        //Debug.Log("Difference in position: " + newTransform.position - previousPosition);

        //newTransform.position = previousPosition;
        //Debug.Log("New angles: " + newAngles);


        newTransform.eulerAngles = newAngles;
        // Fix position so it doesn't pull off 
        newTransform.Translate(anchorPoint.position - leverBottom.position, Space.World);

        return newTransform;
    }
}
