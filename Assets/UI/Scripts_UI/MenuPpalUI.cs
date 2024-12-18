using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


enum BotonesMenuPpalUI
{
    MPPalUI_MenuPrincipal, MPPalUI_Creditos, MPPalUI_Salir, MPPalUI_TotalBotones
}


public class MenuPpalUI : MonoBehaviour
{

    string[] nombreBoton = { "MenuPrincipal", "Creditos", "Salir" };
    Button[] boton;

        // Start is called before the first frame update
        void Start()
        {

        boton = new Button[(int)BotonesMenuPpalUI.MPPalUI_TotalBotones];
        for (int i = (int)BotonesMenuPpalUI.MPPalUI_MenuPrincipal; i < (int)BotonesMenuPpalUI.MPPalUI_TotalBotones; i++) boton[i] = GameObject.Find(nombreBoton[i]).GetComponent<Button>();
        //Calls the jugarClicked method when you click the Button menu
        boton[(int)BotonesMenuPpalUI.MPPalUI_MenuPrincipal].onClick.AddListener(menuClicked);
        //boton[(int)BotonesMenuPpal.MPPal_Cargar].onClick.AddListener(cargarEnter);
        boton[(int)BotonesMenuPpalUI.MPPalUI_Creditos].onClick.AddListener(CreditosClicked);
        boton[(int)BotonesMenuPpalUI.MPPalUI_Salir].onClick.AddListener(VolverJuegoClicked);

    }

        void VolverJuegoClicked()
        {
            Application.Quit(); //Se cierra la aplicaci�n

        SceneManager.LoadScene("Scene");
    }

        void menuClicked()
        {
            //Output this to console when the Button is clicked
            Debug.Log("You have clicked the button Jugar!");
            SceneManager.LoadScene("interfaz");
        }
        void CreditosClicked()
        {
    SceneManager.LoadScene("Creditos");
}

        void Update()
        {
            //Regla del escape
            if (Input.GetKey("escape"))
            SceneManager.LoadScene("Scene");
        //Regla del enter
        if (Input.GetKey(KeyCode.Return))
                menuClicked();
        }



    
      
    }
