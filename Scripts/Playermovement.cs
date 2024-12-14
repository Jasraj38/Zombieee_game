//Pratik Niroula
//Jas Raj Dangi
// priyanka Chaudhary
// Samip Thapa
// In this Code player can move in the direction through comand of (WASD) and space for jump. In this code we added gravity too.
// Priyanka helped on editing ground checked and velocity to the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.8f;

    public bool isGrounded;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //check player id grounded or not and helps for gravity of the player
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
// this is for the velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;


        }

        // this for the movemnet of the player (WASD) is used for moving 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

// We multiply by time because speed is (m/s) so we multiply by time.
        controller.Move(move * speed * Time.deltaTime);
        //velocity for the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // this check for the jump and if the condition is fulfilied 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            // this is for the jump and adding gravity so that player will fall down when he is on the air
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }




    }
}
