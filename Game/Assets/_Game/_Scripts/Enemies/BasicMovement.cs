using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distance;
    [SerializeField] private bool isRight = true;

    [SerializeField] private Transform groundCheck;

    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(isRight)
            transform.Translate(Vector2.right * speed);
        else
            transform.Translate(Vector2.left * speed);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        if (!ground.collider)
            isRight = !isRight;
    }
}
