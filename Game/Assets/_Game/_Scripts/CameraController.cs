using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Vector3 offSet = new(0, 3.5f, 0);

    [SerializeField] private float smoothTime = 5f;

    private Vector3 velocity = Vector3.zero;
    
    private void FixedUpdate()
    {
        Vector3 playerPosition = playerTransform.position;
        
        Vector3 desiredPosition = new Vector3(playerPosition.x + offSet.x, playerPosition.y + offSet.y, transform.position.z);
        
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, Time.deltaTime * smoothTime);
    }
}
