using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera3person : MonoBehaviour
{
    public GameObject lookat;
    public float sensibilidad = 4;
    public float distance = 10f;
    public LayerMask capasNoAtravesables; // Capas de objetos que no deben ser atravesados por la cámara

    float CurrentY = 0f;
    float currentx = 0f;

    float yrotMin = -50f;
    float yrotMax = 50f;

    void Update()
    {
        currentx += Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        CurrentY -= Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        CurrentY = Mathf.Clamp(CurrentY, yrotMin, yrotMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(CurrentY, currentx, 0);

        Vector3 desiredPosition = lookat.transform.position + rotation * Direction;

        // Verificar si hay un obstáculo entre la cámara y el objetivo
        RaycastHit hit;
        if (Physics.Raycast(lookat.transform.position, desiredPosition - lookat.transform.position, out hit, distance, capasNoAtravesables))
        {
            // Si hay un obstáculo, ajusta la posición para evitar colisiones
            transform.position = hit.point;
        }
        else
        {
            // Si no hay obstáculos, establece la posición deseada
            transform.position = desiredPosition;
        }

        transform.LookAt(lookat.transform.position);
    }
}
