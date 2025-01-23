using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


enum BotonesMenuPpalFinal
{
    MPPalFinal_VolverMenuFinal, MPPalFinal_CreditosFinal, MPPalFinal_SalirFinal, MPPalFinal_TotalBotones
}

public class MenuPpalFinal : MonoBehaviour
{

    string[] nombreBoton = { "VolverMenuFinal", "CreditosFinal", "SalirFinal" };
    Button[] boton;



    // Start is called before the first frame update
    void Start()
    {

        boton = new Button[(int)BotonesMenuPpalFinal.MPPalFinal_TotalBotones];
        for (int i = (int)BotonesMenuPpalFinal.MPPalFinal_VolverMenuFinal; i < (int)BotonesMenuPpalFinal.MPPalFinal_TotalBotones; i++) boton[i] = GameObject.Find(nombreBoton[i]).GetComponent<Button>();
        boton[(int)BotonesMenuPpalFinal.MPPalFinal_VolverMenuFinal].onClick.AddListener(volvermenuClicked);
        boton[(int)BotonesMenuPpalFinal.MPPalFinal_CreditosFinal].onClick.AddListener(crdtsJuegoClicked);
        boton[(int)BotonesMenuPpalFinal.MPPalFinal_SalirFinal].onClick.AddListener(salirClicked);

    }

    void volvermenuClicked()
    {

        SceneManager.LoadScene("interfaz");
    }


    void crdtsJuegoClicked()
    {

        SceneManager.LoadScene("Creditos");
    }

    void salirClicked()
    {

        Application.Quit(); //Se cierra la aplicación
        
    }
}