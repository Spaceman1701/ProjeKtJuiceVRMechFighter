using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private ScoreManager scoreManager;
    //private Transform prevLoc; 
    private Vector3 prevPos;
    private Quaternion prevRot;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GetComponentInParent<ScoreManager>();
        prevPos = transform.position;
        prevRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != prevPos || transform.rotation != prevRot)
        {
            // Magnitude of location change + magnitude of rotation change
            float posChange = (transform.position - prevPos).magnitude;
            float angleChange = Mathf.Abs(Quaternion.Angle(transform.rotation, prevRot));
            scoreManager.UpdateScore(posChange*10 + angleChange);
            prevPos = transform.position;
            prevRot = transform.rotation;
        }

        //StartCoroutine(CheckTransform());
    }

    /*public IEnumerator CheckTransform()
    {
        while (true)
        {
            if (transform != prevLoc)
            {
                // Magnitude of location change + magnitude of rotation change
                float posChange = (transform.position - prevLoc.position).magnitude;
                float angleChange = Mathf.Abs(Quaternion.Angle(transform.rotation, prevLoc.rotation));
                Debug.Log("Updating scoremanager with "+posChange+angleChange);
                scoreManager.UpdateScore(posChange + angleChange);
            }
            yield return new WaitForSeconds(0.5f); // Check every half second
        }
    }*/
}
