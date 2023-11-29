using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaramovil : MonoBehaviour
{
    public float velocidadRotacion = 2.0f;
    public float velocidadDesplazamiento = 5.0f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotacionHorizontal = Input.GetAxis("Mouse X") * velocidadRotacion;
            float rotacionVertical = Input.GetAxis("Mouse Y") * velocidadRotacion;

            transform.Rotate(Vector3.up, rotacionHorizontal, Space.World);
            transform.Rotate(Vector3.left, rotacionVertical, Space.Self);
        }

        float desplazamientoHorizontal = Input.GetAxis("Horizontal") * velocidadDesplazamiento * Time.deltaTime;
        float desplazamientoVertical = Input.GetAxis("Vertical") * velocidadDesplazamiento * Time.deltaTime;

        transform.Translate(new Vector3(desplazamientoHorizontal, 0, desplazamientoVertical));
    }
}
