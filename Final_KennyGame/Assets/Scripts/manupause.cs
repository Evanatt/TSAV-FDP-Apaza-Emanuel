using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manupause : MonoBehaviour
{
    public Canvas canvas;
    public GameObject pauseUI;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = true;
        pauseUI.SetActive(false);
    }
    public void exit()
    {
        Application.Quit();
    }

    //Pause
    public void Pause()
    {
        canvas.enabled = true;
        pauseUI.SetActive(true);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void volver()
    {
        pauseUI.SetActive(false);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    public void menu()
    {
        pauseUI.SetActive(false);
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        SceneManager.LoadScene(0);
    }
    public void reiniciar()
    {
        pauseUI.SetActive(false);
        canvas.enabled = false;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        SceneManager.LoadScene(1);
    }
    public void escena3()
    {
        pauseUI.SetActive(false);
        canvas.enabled = false;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        SceneManager.LoadScene(2);
    }
    public void escena4()
    {
        pauseUI.SetActive(false);
        canvas.enabled = false;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        SceneManager.LoadScene(3);
    }
    void Update()
    {

        //Al presionar la tecla "p"
        if (Input.GetKeyDown("p"))
        {
            Pause();
        }
    }
}
