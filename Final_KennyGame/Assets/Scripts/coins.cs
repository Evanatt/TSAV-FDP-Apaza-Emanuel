using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    public Transform target;
    public float speed = 6.0f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Playercontroller>().monedas += 1;
            Destroy(gameObject);
        }
        // Destroy(gameObject);
    }
}
