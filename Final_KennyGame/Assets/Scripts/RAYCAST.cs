using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAYCAST : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                interactuable interactuable=hit.collider.GetComponent<interactuable>();
                if (interactuable!=null)
                {
                    interactuable.Interact();
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}
