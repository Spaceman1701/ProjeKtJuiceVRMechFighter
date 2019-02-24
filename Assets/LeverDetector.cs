using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDetector : MonoBehaviour
{

    public bool fall_out_boy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider otherCollider) {
        if (otherCollider.GetComponentInParent<LeverGrabAction>() != null) {
            this.fall_out_boy = true;
        }
    }

    public void OnTriggerExit(Collider otherCollider) {
        if (otherCollider.GetComponentInParent<LeverGrabAction>() != null) {
            this.fall_out_boy = false;
        }
    }
}
