using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class fuentes : MonoBehaviour
{
    public Animator anim;
    public List<GameObject> rocasEnLugar = new List<GameObject>();

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Roca1") || collision.gameObject.CompareTag("Roca2"))
        {
            rocasEnLugar.Add(collision.gameObject);
            ActualizarAnimacion();
            Debug.Log(collision.gameObject.tag + " en el lugar correcto en la fuente");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Roca1") || collision.gameObject.CompareTag("Roca2"))
        {
            rocasEnLugar.Remove(collision.gameObject);
            cancelaranimacion(collision.gameObject.tag);
            Debug.Log(collision.gameObject.tag + " salió del lugar correcto en la fuente");
        }
    }
    void ActualizarAnimacion()
    {
        // Activa las animaciones según las rocas presentes
        foreach (var roca in rocasEnLugar)
        {
            if (roca.CompareTag("Roca1"))
            {
                anim.SetBool("Activaobjeto1", true);
            }
            else if (roca.CompareTag("Roca2"))
            {
                anim.SetBool("Activaobjeto2", true);
            }
        }
    }
    void cancelaranimacion(string rocaTag)
    {
        // Desactiva la animación correspondiente a la roca que sale
        if (rocaTag == "Roca1")
        {
            anim.SetBool("Activaobjeto1", false);
        }
        else if (rocaTag == "Roca2")
        {
            anim.SetBool("Activaobjeto2", false);
        }
    }
}
