using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerSpeed;
    private CharacterController playerController;
    private bool isOnGround;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerController = this.GetComponent<CharacterController>(); //Get the character controller reference
        playerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 playerWalkDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        isOnGround = playerController.isGrounded;
        if (isOnGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerController.Move(playerWalkDirection * PlayerSpeed * Time.deltaTime);

        if (playerWalkDirection != Vector3.zero)
        {
            gameObject.transform.forward = playerWalkDirection;
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

        playerWalkDirection.y += gravityValue * Time.deltaTime;
        playerVelocity.y += gravityValue * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);

        
    }
}
