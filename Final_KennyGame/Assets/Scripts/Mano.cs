using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    public float grabRange = 5f; // Rango de agarre
    public Transform holdingPosition; // Posición donde se mantiene el objeto agarrado
    private GameObject grabbedObject; // Objeto actualmente agarrado
    public Rigidbody rb;
    public Rigidbody rb2;

    public AudioClip grabSound; // Clip de sonido al agarrar
    public AudioClip releaseSound; // Clip de sonido al soltar
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb2 = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        if (rb2 != null)
        {
            rb2.isKinematic = true;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (grabbedObject == null)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        if (grabbedObject != null)
        {
            MoveGrabbedObject();
        }
    }

    public void TryGrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
        {
            if (hit.collider.CompareTag("Roca1") || hit.collider.CompareTag("Roca2"))
            {
                GrabObject(hit.collider.gameObject);
            }

        }
    }

    public void GrabObject(GameObject obj)
    {
        grabbedObject = obj;
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.parent = holdingPosition;
        grabbedObject.transform.localPosition = Vector3.zero;

        PlaySound(grabSound);
    }

    public void ReleaseObject()
    {
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.parent = null;
        grabbedObject = null;

        PlaySound(releaseSound);
    }

    public void MoveGrabbedObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = holdingPosition.position;
        }
    }
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
