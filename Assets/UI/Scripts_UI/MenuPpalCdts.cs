using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


enum BotonesMenuPpalCdtos
{
    MPPalCdts_SalirCreditos, MPPalCdts_VolverJuego, MPPalCdts_TotalBotones
}


public class MenuPpalCdts : MonoBehaviour
{

    string[] nombreBoton = { "SalirCreditos", "VolverJuego" };
    Button[] boton;



    // Start is called before the first frame update
    void Start()
    {

        boton = new Button[(int)BotonesMenuPpalCdtos.MPPalCdts_TotalBotones];
        for (int i = (int)BotonesMenuPpalCdtos.MPPalCdts_SalirCreditos; i < (int)BotonesMenuPpalCdtos.MPPalCdts_TotalBotones; i++) boton[i] = GameObject.Find(nombreBoton[i]).GetComponent<Button>();
        boton[(int)BotonesMenuPpalCdtos.MPPalCdts_SalirCreditos].onClick.AddListener(salirCrdClicked);
        boton[(int)BotonesMenuPpalCdtos.MPPalCdts_VolverJuego].onClick.AddListener(volverJuegoClicked);

    }

    void salirCrdClicked()
    {

        SceneManager.LoadScene("interfaz");
    }


    void volverJuegoClicked()
    {

        SceneManager.LoadScene("Scene");
    }

}
