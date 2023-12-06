using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEditor.UI;

public class Playercontroller : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public float playerSpeed;
    public Vector3 playervelocity;
    public bool groundedPLayer;
    public float monedas = 0;
    public canvasmain act;

    public Transform camera;
    public float turnVelocitySmooth = 0.1f;
    public float turnSmoothTime;

    public float jumpheigh;
    public float gravityValue;
    public float gravitMutiplay;

    bool isFalling = false;

    public Mano grabbedObject;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate() {

        Grounded();
        gravity();
        Jump();
        Move();
 
        if (monedas == 10) {
            act.Activarcanvas();
        }
        if (!groundedPLayer && playervelocity.y <= 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        // Activa el trigger de caída en el Animator
        anim.SetBool("isFalling", isFalling);
        if (grabbedObject != null)
        {
            grabbedObject.MoveGrabbedObject();
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && groundedPLayer)
        {
            playervelocity.y += Mathf.Sqrt(jumpheigh * -3.0f * gravityValue);
            anim.SetBool("Jump", true);

            
        }
        else
        {
            anim.SetBool("Jump", false);
        }

    }
    private void gravity() {
        playervelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playervelocity * Time.deltaTime);
    }
    private void Grounded()
    {
        groundedPLayer = controller.isGrounded;
        if (groundedPLayer && playervelocity.y < 0)
        {
            playervelocity.y = 0f;
        }
    }

    private void Move()
    {

        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3 (horizontalAxis,0, verticalAxis).normalized;
        this.anim.SetFloat("SpeedZ", move.z);
        this.anim.SetFloat("SpeedX", move.x);
        this.anim.SetFloat("Magnitude", move.magnitude);

        if (move.magnitude >= 0.1f)
        {
            float targetAngle;
            Vector3 moveDir;
            //float targetAngle Mathf.Atan2(move.x, nove.z) Mathf.Rad2Deg; //Independiente de la camara.
            if (Input.GetButton("Fire1"))
            {
                anim.SetBool("Camfocused", true);
                targetAngle = camera.eulerAngles.y; //Dependiente de la camara.
                moveDir = move.z * transform.forward + transform.right * move.x;
            }
            else
            {
                targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + camera.eulerAngles.y; //Independiente de la camara, pero con la camara como su forward.
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                anim.SetBool("Camfocused", false);
            }
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocitySmooth, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Sprinting", true);
                controller.Move(moveDir.normalized * playerSpeed * 2.7f * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Sprinting", false);
            }
        }
    } 
    
}
