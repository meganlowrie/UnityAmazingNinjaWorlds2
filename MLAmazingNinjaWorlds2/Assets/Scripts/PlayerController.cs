using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // get a reference to Codey's animator
    public Animator animatorClip;

    // get a reference to Codey's rigidbody for physics calculations
    private Rigidbody rigidBody;

    // store if Codey is currently on the ground
    [SerializeField]
    public bool onGround;

    // store how far away Codey is from the ground
    public float centerOfCodeyToFeetDistance;

    // when the script starts
    // initialize Codey on the ground
    // and get references to Codey's rigidbody, animator, 
    // and the current distance from Codey's collider to the ground
    void Start()
    {
        onGround = true;
        rigidBody = GetComponent<Rigidbody>();
        animatorClip = GetComponent<Animator>();
        centerOfCodeyToFeetDistance = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        // get the user's horizontal input
        // this will be a value between -1 and 1
        float horizontal = Input.GetAxis("Horizontal");

        // if the user input is negative, rotate Codey to the left
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        // if the user input is positive, rotate Codey to the right
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }


        // get Codey's current y velocity
        float verticalVelocity = rigidBody.velocity.y;

        // ask Unity to see if Codey is colliding with the ground
        // by looking from Codey's center down 
        // but only look through the distance from Codey's center to his feet
        // if Codey is on the ground, then make sure his vertical velocity is 0
        if (Physics.Raycast(transform.position, Vector3.down, centerOfCodeyToFeetDistance))
        {
            verticalVelocity = 0;
            onGround = true;
        } else
        {
            onGround = false;
        }

        animatorClip.SetFloat("horizontalVector", horizontal);
        animatorClip.SetFloat("verticalVector", verticalVelocity);
    }
}
