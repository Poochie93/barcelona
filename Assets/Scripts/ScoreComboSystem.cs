using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComboSystem : MonoBehaviour
{
    // Puntuación inicial
    private int score = 0;

    // Método para agregar puntos
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntos agregados: " + points + ". Puntuación total: " + score);
    }

    // Método para obtener la puntuación actual
    public int GetScore()
    {
        return score;
    }
}
