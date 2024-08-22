using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float activeMoveSpeed;
    public float acceleration;
    public float deceleration;
    public float jumpPower;
    public bool onGround;
    public float groundDrag;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }

    public void Update()
    {
        jump();

        /*
        if (onGround)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        /*
        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;
        
        float targetSpeedX = direction.x * activeMoveSpeed;
        float targetSpeedZ = direction.y * activeMoveSpeed;

        targetSpeedX = Mathf.Lerp(rb.velocity.x, targetSpeedX, 1);
        targetSpeedZ = Mathf.Lerp(rb.velocity.z, targetSpeedZ, 1);

        float speedDifX = targetSpeedX - rb.velocity.x;
        float speedDifY = targetSpeedZ - rb.velocity.z;

        float accelRateX = (Mathf.Abs(targetSpeedX) > 0.1f) ? acceleration : deceleration;
        float accelRateZ = (Mathf.Abs(targetSpeedZ) > 0.1f) ? acceleration : deceleration;

        float movementX = speedDifX * accelRateX;
        float movementZ = speedDifY * accelRateZ;
        */

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        rb.AddRelativeForce(Vector3.forward * verticalInput * activeMoveSpeed, ForceMode.Force);
        //new Vector3(movementX, 0, movementZ), ForceMode.Force);
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
