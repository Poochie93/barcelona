using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;
    public void AddPoints(int points)
    {

        score += points;
        Debug.Log("Currrent Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

}
