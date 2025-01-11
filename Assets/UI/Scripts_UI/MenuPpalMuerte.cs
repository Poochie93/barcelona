using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum BotonesMenuPpalMuerte
{
    MPPal_VolverMuerte, MPPal_SalirJuegoMuerte, MPPalMuerte_TotalBotones
}


public class MenuPpalMuerte : MonoBehaviour
{
    string[] nombreBoton = { "VolverMuerte", "SalirJuegoMuerte" };
    Button[] boton;



    // Start is called before the first frame update
    void Start()
    {

        boton = new Button[(int)BotonesMenuPpalMuerte.MPPalMuerte_TotalBotones];
        for (int i = (int)BotonesMenuPpalMuerte.MPPal_VolverMuerte; i < (int)BotonesMenuPpalMuerte.MPPalMuerte_TotalBotones; i++) boton[i] = GameObject.Find(nombreBoton[i]).GetComponent<Button>();
        boton[(int)BotonesMenuPpalMuerte.MPPal_VolverMuerte].onClick.AddListener(VolverMuerteClicked);
        boton[(int)BotonesMenuPpalMuerte.MPPal_SalirJuegoMuerte].onClick.AddListener(SalirJuegoMuerteClicked);

    }

    void VolverMuerteClicked()
    {

        SceneManager.LoadScene("interfaz");
    }


    void SalirJuegoMuerteClicked()
    {

        Application.Quit(); //Se cierra la aplicación
        UnityEditor.EditorApplication.isPlaying = false;
    }

}