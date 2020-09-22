using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class twoDAnimationController : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0f;
    float velocityX = 0f;
    public float acceleration = 2f;
    public float decceleration = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //search the gameobject the script is attached to and get the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get key input from player
        //bool forwardPressed = Input.GetKey("w");
        //bool leftPressed = Input.GetKey("a");
        //bool rightPressed = Input.GetKey("d");
        //bool runPressed = Input.GetKey("left shift");

        //if player presses forward, increase velocity in z direction (forward)
        if (forwardPressed && velocityZ < 0.5f && !runPressed)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        //increase velocity in the left direction
        if (leftPressed && velocityX > -0.5f && !runPressed)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        //increase velocity in the right direction
        if (rightPressed && velocityX < 0.5f && !runPressed)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //decrease velocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * decceleration;
        }

        //reset velocity
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0f;
        }

        //increase velocityX if left is not pressed and VelX < 0
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * decceleration;
        }

        //decrease velx if right is not pressed and velx > 0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * decceleration;
        }

        if (!leftPressed && !rightPressed && velocityX != 0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0f;
        }

        //set parameters to our local variable values
        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);

    }
}
