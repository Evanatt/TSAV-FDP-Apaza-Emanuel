using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask LayerMask;
    public bool grounded;
    public float monedas=0;
    public canvasmain act;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Grounded();
        Jump();
        Move();
        if (monedas==10) {
            act.Activarcanvas();
        }
    }
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded) {
            this.rb.AddForce(Vector3.up* 4, ForceMode.Impulse);
        }
    }
    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, LayerMask))
        {
            this.grounded = true;
        }      
else
        {
            this.grounded = false;
        }
        this.anim.SetBool("jump", this.grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.position += movement * 0.04f;
        this.anim.SetFloat("SpeedZ", verticalAxis);
        this.anim.SetFloat("SpeedX", horizontalAxis);
    }

}
