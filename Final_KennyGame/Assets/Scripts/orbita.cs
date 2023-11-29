using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbita : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadRotacion = 2.0f;

    void Update()
    {
        transform.RotateAround(objetivo.position, Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
