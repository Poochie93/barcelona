using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VolverAjustes : MonoBehaviour
{
    // Start is called before the first frame update
   
        void EscClicked()
        {
            //Output this to console when the Button is clicked
         
            SceneManager.LoadScene("Ajustes");
        }
    

    // Update is called once per frame
    void Update()
    {
        //Regla del escape
        if (Input.GetKey("escape"))
            EscClicked();
        //Regla del enter
       
    }
}
