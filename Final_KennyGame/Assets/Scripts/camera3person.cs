using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera3person : MonoBehaviour
{
    public GameObject lookat;
    public float sensibilidad = 4;
    public float distance = 10f;

    float CurrentY = 0f;
    float currentx = 0f;

    float yrotMin = -50f;
    float yrotMax = 50f;
    Vector2 rotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentx += Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        CurrentY -= Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        CurrentY = Mathf.Clamp(CurrentY, yrotMin, yrotMax);

        Vector3 Direction = new Vector3(0,0, -distance);
        Quaternion rotation = Quaternion.Euler(CurrentY, currentx, 0);

        transform.position= lookat.transform.position + rotation * Direction;
        transform.LookAt(lookat.transform.position);

    }
}
