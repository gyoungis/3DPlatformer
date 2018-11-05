using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    // Movement Variables
    private Vector3 moveVec;
    private float moveSpeed = 5f;
    private float rotationSpeed = 1f;
    private Rigidbody rb;

    // Jump Variables
    private float distToGround;
    private float jumpSpeed = 20.0f;
    private float jumpForce = 4.0f;
    private Vector3 jump;
    private float gravity = 10.0f;
    private bool singleJump = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            // Move Forward
            moveVec = new Vector3(cam.transform.forward.x, gameObject.transform.right.y, cam.transform.forward.z);
            moveDir += moveVec;
            gameObject.transform.forward = new Vector3(cam.transform.forward.x, gameObject.transform.right.y, cam.transform.forward.z);

        }
        if (Input.GetKey(KeyCode.S))
        {
            // Move Backward
            moveVec = new Vector3(cam.transform.forward.x, gameObject.transform.right.y, cam.transform.forward.z);
            moveDir -= moveVec;
            gameObject.transform.forward = new Vector3(cam.transform.forward.x, gameObject.transform.right.y, cam.transform.forward.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Move to the Left
            moveDir += -cam.transform.right;
            gameObject.transform.forward = new Vector3(-cam.transform.right.x, gameObject.transform.right.y, -cam.transform.right.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Move to the Right
            moveDir += cam.transform.right;
            gameObject.transform.forward = new Vector3(cam.transform.right.x, gameObject.transform.right.y, cam.transform.right.z);
        }

        if (!IsGrounded())
        {
            //moveDir.y -= gravity * Time.deltaTime * Time.deltaTime;
            singleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Jump
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDir), rotationSpeed * Time.deltaTime);
        }
    }

    bool IsGrounded()
    {
        Debug.Log(Physics.Raycast(transform.position, -gameObject.transform.up, distToGround + 0.1f));
        return Physics.Raycast(transform.position, -gameObject.transform.up, distToGround + 0.1f);
    }
}
