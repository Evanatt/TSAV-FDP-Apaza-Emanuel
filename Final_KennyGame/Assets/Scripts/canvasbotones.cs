using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasbotones : MonoBehaviour
{
    
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void salir()
    {
        Application.Quit();
    }
    public void volveralmenuprincipal()
    {
        SceneManager.LoadScene(0);

    }
    public void Escena3()
    {
        SceneManager.LoadScene(2);
    }
    public void Escena4()
    {
        SceneManager.LoadScene(3);
    }
}
