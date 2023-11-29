using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerafirstPerson : MonoBehaviour
{
    public GameObject player;
    const string XAxis = "Mouse X";
    const string YAxis = "Mouse Y";

    public float sensibilidad = 100;
   
    float yrotMin = -60f;
    float xrotMin = 60f;
    Vector2 rotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x= Input.GetAxis("Mouse X")*sensibilidad*Time.deltaTime;
        rotation.y = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        rotation.y = Mathf.Clamp(rotation.y, yrotMin, xrotMin);
        player.transform.Rotate(Vector3.up, rotation.x);

        transform.localRotation = Quaternion.Euler(rotation.y, 0, 0);
    }
}
