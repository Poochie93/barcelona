using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


enum BotonesMenuPpal
{
    MPPal_Jugar, MPPal_Opciones, MPPal_Salir, MPPal_TotalBotones
}


public class MenuPpal : MonoBehaviour
{

    string[] nombreBoton = { "Jugar", "Opciones", "Salir" };
    Button[] boton;





    // Start is called before the first frame update
    void Start()
    {

        boton = new Button[(int)BotonesMenuPpal.MPPal_TotalBotones];
        for (int i = (int)BotonesMenuPpal.MPPal_Jugar; i < (int)BotonesMenuPpal.MPPal_TotalBotones; i++) boton[i] = GameObject.Find(nombreBoton[i]).GetComponent<Button>();
        //Calls the jugarClicked method when you click the Button Jugar
        boton[(int)BotonesMenuPpal.MPPal_Jugar].onClick.AddListener(jugarClicked);
        //boton[(int)BotonesMenuPpal.MPPal_Cargar].onClick.AddListener(cargarEnter);
        boton[(int)BotonesMenuPpal.MPPal_Opciones].onClick.AddListener(opcionesClicked);
        boton[(int)BotonesMenuPpal.MPPal_Salir].onClick.AddListener(salirClicked);

    }

    void salirClicked()
    {
        Application.Quit(); //Se cierra la aplicación
                            //Se cierra la ejecución si se está en el entorno de desarrollo Unity 3D
      //  UnityEditor.EditorApplication.isPlaying = false;
    }

    void jugarClicked()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button Jugar!");
        SceneManager.LoadScene("Scene");
    }
    void opcionesClicked()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button Jugar!");
        SceneManager.LoadScene("Ajustes");
    }

    void genericClicked(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }

    void Update()
    {
        //Regla del escape
        if (Input.GetKey("escape"))
            salirClicked();
        //Regla del enter
        if (Input.GetKey(KeyCode.Return))
            jugarClicked();
    }





}
