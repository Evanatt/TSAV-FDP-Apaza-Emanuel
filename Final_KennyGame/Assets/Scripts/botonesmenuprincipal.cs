using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonesmenuprincipal : MonoBehaviour
{
    public void escena2()
    {
        SceneManager.LoadScene(1);
    }
    public void escena3()
    {
        SceneManager.LoadScene(2);
    }
    public void exit()
    {
        Application.Quit();
    }
}
