using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [SerializeField]
    public Animator anim;

    
    public Camera Cameracam;
    public float turnvelocitySmo=0.1f;
    public float turnsmoTime = 0.1f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim= GetComponent<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.forward* vertical+transform.right*horizontal;

        move = move.normalized;
        anim.SetFloat("SpeedX",move.x);
        anim.SetFloat("SpeedZ", move.z);

        anim.SetFloat("SpeedMag", move.magnitude);
        if (move.magnitude >= 0.1)
        {
           
            controller.Move(move.normalized * Time.deltaTime * playerSpeed);
        }
        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            anim.SetTrigger("Jump");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
