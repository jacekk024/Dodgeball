using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;



    public Transform groundCheck; // sprawdzanie kolizji z ziemia
    public float groundDistance = 0.4f; //odleglosc od ziemi
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) { //sprawdzenie czy jest na ziemi 
            velocity.y = -2f;
        }


        if (isGrounded) // poruszanie sie gdy jest na ziemi
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
        else { // poruszanie sie podczas skoku
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = /* transform.right * x * 0.65f +*/ transform.forward * z * 0.65f;
            if (z >= 0)
            {
                controller.Move(move * speed * Time.deltaTime);
            }

        }

        if (Input.GetButtonDown("Jump") && isGrounded) { //mechanika skoku

            velocity.y = Mathf.Sqrt(jumpHeight * (-2f) * gravity);
        }

        velocity.y += gravity * Time.deltaTime; // grawitacja 

        controller.Move(velocity * Time.deltaTime); 


    }
}
