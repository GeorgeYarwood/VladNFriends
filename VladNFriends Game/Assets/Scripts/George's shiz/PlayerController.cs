using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isSprinting = false;

    float xRot = 0;
    float yRot = 0;

    [SerializeField] float sens = 4;
    [SerializeField] float moveSpeed = 35;
    [SerializeField] float actualMoveSpeed = 35;
    [SerializeField] float jumpForce = 1000;
    [SerializeField] float sprintMult = 1.5f;

    float jumpTime = 1;

    bool canJump;

    Vector3 upVec = new Vector3(0, 1, 0);

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        //Hide and lock cursor
        Cursor.lockState = CursorLockMode.Locked;

        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSprinting)
        {
            actualMoveSpeed = moveSpeed * sprintMult;
        }
        else if (!isSprinting)
        {
            actualMoveSpeed = moveSpeed;
        }
        
        if (Input.GetKey("w"))
        {
            playerRb.AddForce(playerRb.transform.forward * actualMoveSpeed);
        }
        if (Input.GetKey("s"))
        {
            playerRb.AddForce(playerRb.transform.forward * -actualMoveSpeed);
        }

        if (Input.GetKey("a"))
        {
            playerRb.AddForce(Vector3.Cross(playerRb.transform.forward, upVec.normalized) * actualMoveSpeed);
        }
        if (Input.GetKey("d"))
        {
            playerRb.AddForce(-(Vector3.Cross(playerRb.transform.forward, upVec.normalized) * actualMoveSpeed));
        }
        if (Input.GetKey(KeyCode.Space) && canJump) 
        {
            playerRb.AddForce(playerRb.transform.up * jumpForce);
            StartCoroutine(waitJump());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        //Get mouse movements
        float horizontal = sens * Input.GetAxis("Mouse X");
        float vertical = sens * Input.GetAxis("Mouse Y");


        //Assign and invert Y axis
        xRot += Input.GetAxis("Mouse Y") * -sens;
        yRot += Input.GetAxis("Mouse X") * sens;

        //Apply rotation to rigidbody
        playerRb.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
    }

    IEnumerator waitJump() 
    {
        canJump = false;
        yield return new WaitForSeconds(jumpTime);
        canJump = true;
    }
}
