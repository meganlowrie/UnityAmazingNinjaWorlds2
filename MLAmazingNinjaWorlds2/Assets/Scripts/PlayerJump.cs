using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // create public variables that describe Codey's jump movement
    // these are initialized but can be altered in the Inspector
    public float jumpStrength = 18f;
    public float fallMultiplier = 1.5f;
    public float jumpMultiplier = 1f;

    // create a reference for Codey's game object
    public GameObject codeyGameObject;

    // create a reference to Codey's rigidbody
    private Rigidbody rigidBody;

    // create a reference to Codey's player controller
    // to see if Codey is on the ground or not
    private PlayerController playerController;

    // store the references to Codey's rigidbody and player controller
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerController = codeyGameObject.GetComponent<PlayerController>();
    }

    // use FixedUpdate because we are calculating physics
    void FixedUpdate()
    {
        // if the user presses the jump button (space)
        // and Codey is on the ground
        if (Input.GetButtonDown("Jump") && playerController.onGround)
        {
            // and apply a velocity in the up direction (0, 1, 0) with
            // a magnitude of Codey's jump strength
            rigidBody.velocity = Vector3.up * jumpStrength;
        }

        // each frame calculate the effects of gravity
        // and change the value of the Codey's velocity
        // if Codey's velocity is negative
        // then Codey is falling and we use the fallMultiplier
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }
        // and if Codey's velocity is positive
        // then Codey is jumping and we use the jumpMulitiplier
        else if (rigidBody.velocity.y > 0)
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * jumpMultiplier * Time.fixedDeltaTime;
        }

    }

}
