using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Move Forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //rotate Y axis
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }


}
