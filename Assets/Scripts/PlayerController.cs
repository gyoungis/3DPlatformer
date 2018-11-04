using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform camTransform;

    // Movement Variables
    private float moveSpeed = 5f;
    private float rotationSpeed = 1f;
    private Rigidbody rb;

    // Jump Variables
    private float jumpSpeed = 8.0f;
    private float gravity = 20.0f;
    private bool singleJump = false;
    private bool doubleJump = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            // Move Forward
            moveDir += camTransform.forward;
            gameObject.transform.forward = camTransform.forward;

        }
        if (Input.GetKey(KeyCode.S))
        {
            // Move Backward
            moveDir += -camTransform.forward;
            gameObject.transform.forward = camTransform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Move to the Left
            moveDir += -camTransform.right;
            gameObject.transform.forward = -camTransform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Move to the Right
            moveDir += camTransform.right;
            gameObject.transform.forward = camTransform.right;
        }
        //moveDir.y = moveDir.y -= gravity * Time.deltaTime; ;
        moveDir.y = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Jump
            if (!doubleJump)
            {
                if (singleJump)
                {
                    moveDir.y = jumpSpeed;
                    singleJump = false;
                    doubleJump = true;
                }
                else
                {
                    moveDir.y = jumpSpeed;
                    singleJump = true;
                }
            }
        }
        transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDir), rotationSpeed * Time.deltaTime);
        }
    }
}
