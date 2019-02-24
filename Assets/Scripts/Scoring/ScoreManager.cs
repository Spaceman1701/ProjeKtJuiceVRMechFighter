using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score = 0f;

    // Track all the scoreable objects

    public void UpdateScore(float newScore)
    {
        score += newScore;
    }
}
