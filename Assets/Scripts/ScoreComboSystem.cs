using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComboSystem : MonoBehaviour
{
    // Puntuaci�n inicial
    private int score = 0;

    // M�todo para agregar puntos
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntos agregados: " + points + ". Puntuaci�n total: " + score);
    }

    // M�todo para obtener la puntuaci�n actual
    public int GetScore()
    {
        return score;
    }
}
