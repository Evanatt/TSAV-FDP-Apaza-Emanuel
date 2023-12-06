using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator anim;
    public List<fuentes> fuentesScripts;

    void Start()
    {
        anim = GetComponent<Animator>();
        fuentesScripts = new List<fuentes>(FindObjectsOfType<fuentes>());
    }

    void Update()
    {
        bool todasFuentesCorrectas = true;

        foreach (var fuenteScript in fuentesScripts)
        {
            if (fuenteScript.rocasEnLugar.Count < 2)
            {
                todasFuentesCorrectas = false;
                break;
            }
        }

        anim.SetBool("Abierta", todasFuentesCorrectas);
    }
}
