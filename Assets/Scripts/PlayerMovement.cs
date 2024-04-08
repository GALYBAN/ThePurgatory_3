using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;

    public GroundSensor sensor; 

    public SpriteRenderer render; 

    public Animator anim;

    AudioSource source;

   /* public Vector3 newPosition = new Vector3(50, 5, 0); */

    public float movementSpeed = 10;
    public float jumpForce = 10;

    private float inputHorizontal;

    public bool jump = false;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        /*source = GetComponent<AudioSource>();*/
    }
    
    // Update is called once per frame
    void Update()
    {

        inputHorizontal = Input.GetAxis("Horizontal"); //Los controladores se ponen en el Update


        if(Input.GetButtonDown("Jump") & sensor.isGrounded == true) 
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            /*anim.SetBool("IsJumping", true);*/
        }

        if(inputHorizontal < 0 )
        {
            render.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if(inputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y); //Cuando trabajamos con fisicas de forma continua, trabajamos en el FixedUpdate.
    }
}
