using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.03f;
    [SerializeField] private float distance = 1;
    [SerializeField] private bool isRight = true;
    [SerializeField] private bool seePlayer = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask playerlayer;

    [SerializeField] private Vector2 rangeVision = new Vector2(4, 1);

    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if(!seePlayer)
            transform.Translate(Vector2.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        detectBorder();

        findPlayer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, rangeVision);
    }

    private void findPlayer()
    {
        Collider2D coll = Physics2D.OverlapBox(transform.position, rangeVision, 0f, playerlayer);
        if (coll != null)
        {
            seePlayer = true;
            Debug.Log("Player encontrado");
        }
        else
        {
            seePlayer = false;
        }
    }

    private void detectBorder()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        
        if (!ground.collider)
        {
            isRight = !isRight;
            if(isRight)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
