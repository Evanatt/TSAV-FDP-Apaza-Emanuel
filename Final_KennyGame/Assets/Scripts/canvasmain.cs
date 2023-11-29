using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasmain : MonoBehaviour
{
    public TextMeshProUGUI contador;
    public Playercontroller chica;
    public GameObject Complete;
    private void Start()
    {
        Complete.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        contador.text = chica.monedas + "/10";

    }
    public void Activarcanvas()
    {
        Complete.SetActive(true);
    }
    public void Volveralinicio()
    {
        Complete.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
