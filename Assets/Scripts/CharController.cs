using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    CharacterController controller;

    public Camera cam;                                                                                        

    private float jumpSpeed = 20.0F;
    private float gravity = 5.0F;
    private float speed = 7.0f;
    private float jumpMove;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpMove = 0.3f * speed;
        // Hides mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            // Determines movement of player
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                gameObject.transform.forward = new Vector3(cam.transform.forward.x, gameObject.transform.forward.y, cam.transform.forward.z);
            }
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        //else
        //{
        //    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        //    {
        //        gameObject.transform.forward = new Vector3(cam.transform.forward.x, gameObject.transform.forward.y, cam.transform.forward.z);
        //    }
        //    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //    moveDirection = transform.TransformDirection(moveDirection);

        //    moveDirection.x *= jumpMove;
        //    moveDirection.z *= jumpMove;
        //}

        // Final player Movement
        moveDirection.y -= gravity*gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);        

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
