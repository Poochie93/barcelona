using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    public Image Vida;

    public PlayerLife playerLife;

    // Update is called once per frame
    void Update()
    {
        // Asegurarse de que playerLife no es null
        if (playerLife != null)
        {
            // Comprobar si maxHealth es mayor que 0 para evitar una división por 0
            if (playerLife.maxHealth > 0)
            {
                // Convertir a float para obtener un valor decimal
                Vida.fillAmount = (float)playerLife.currentHealth / playerLife.maxHealth;
            }
            else
            {
                Vida.fillAmount = 0; // Si maxHealth es 0, la barra de vida se llena completamente
            }
        }
        else
        {
            Debug.LogError("PlayerLife no está asignado en el script BarradeVida.");
        }
    }
}