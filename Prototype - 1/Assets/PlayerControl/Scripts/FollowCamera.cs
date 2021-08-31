using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject vehicle;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 7, -14);
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = vehicle.transform.position + cameraOffset;
    }
}
