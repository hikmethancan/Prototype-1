using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed ;
    [SerializeField] float rpm ;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float horsePower;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Move Forward
        if (isOnGround())
        {
            rb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            //rotate Y axis
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
            speed = Mathf.Round(rb.velocity.magnitude * 2.237f);
            speedometer.text = "Speed: " + speed + "MPH";
            rpm = Mathf.Round(speed % 30) * 40;
            rpmText.text = "RPM : " + rpm;
        }
        
    }


    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
