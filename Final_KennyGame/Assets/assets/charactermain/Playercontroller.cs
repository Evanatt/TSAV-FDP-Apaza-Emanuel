using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public float playerSpeed;
    private Rigidbody rb;
    public LayerMask LayerMask;
    public bool grounded;
    public float monedas = 0;
    public canvasmain act;
    public Transform camera;
    public float turnVelocitySmooth=0.1f;
    public float turnSmoothTime;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Grounded();
        Jump();
        Move();
        if (monedas == 10) {
            act.Activarcanvas();
        }
    }
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded) {
            this.rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
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
        Vector3 move = new Vector3 (horizontalAxis, 0, verticalAxis).normalized;
        movement.Normalize();

        this.transform.position += movement * 0.04f;
        this.anim.SetFloat("SpeedZ", move.z);
        this.anim.SetFloat("SpeedX", move.x);
        
        if (move.magnitude >= 0.1f) {
            float targetAngle;
            Vector3 moveDir;
            
            //float targetAngle Mathf.Atan2(move.x, nove.z) Mathf.Rad2Deg; //Independiente de la camara.
            if (Input.GetButton("Fire1")) {
                anim.SetBool("Camfocused", true);
                targetAngle = camera.eulerAngles.y; //Dependiente de la camara.
                moveDir = move.z * transform.forward + transform.right* move.x;
            }
            else {
                targetAngle = Mathf.Atan2(move.x, move.z)* Mathf.Rad2Deg + camera.eulerAngles.y; //Independiente de la camara, pero con la camara como su forward.
                moveDir = Quaternion.Euler(0f, targetAngle, 0f)* Vector3.forward;
                anim.SetBool("Camfocused", false);
            }
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocitySmooth, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
        }
    } 
}
