using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public GameObject canvasfinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            canvasfinal.SetActive(true);
        }
    }
}
