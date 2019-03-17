using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverAJugar(){
        SceneManager.LoadScene("Escena1", LoadSceneMode.Single);
    }

    public void Salir(){
         Application.Quit();
    }

    public void PlayGmane(){
         SceneManager.LoadScene("Escena1", LoadSceneMode.Single);
    }

}
