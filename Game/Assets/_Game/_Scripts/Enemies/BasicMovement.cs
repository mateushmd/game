using System;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.03f;
    [SerializeField] private float distance = 1;
    [SerializeField] private bool isRight = true;
    [SerializeField] private bool seePlayer = false;
    private bool onBord = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerlayer;
    [SerializeField] private float minDistance;

    [SerializeField] private Vector2 rangeVision = new Vector2(4, 3);

    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (!seePlayer)
            Movement();
        else
            FollowPLayer();
    }

    // Update is called once per frame
    void Update()
    {
        DetectBorder();

        FindPlayer();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, rangeVision);
        if(seePlayer)
            Gizmos.DrawLine(transform.position, player.position);
    }

    private void FindPlayer()
    {
        Collider2D coll = Physics2D.OverlapBox(transform.position, rangeVision, 0f, playerlayer);
        if (coll != null)
        {
            Vector2 position = transform.position;
            Vector2 playerPosition = coll.transform.position;
            Vector2 direction = playerPosition - position;
            RaycastHit2D hit = Physics2D.Raycast(position, direction.normalized, playerlayer);
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    seePlayer = true;
                }
                else
                {
                    seePlayer = false;
                }
            }
            else
            {
                seePlayer = false;
            }
        }
        else
        {
            seePlayer = false;
        }
    }

    private void DetectBorder()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        
        if (!ground.collider)
        {
            onBord = true;
        }
        else
        {
            onBord = false;
        }
    }
    
    private void Movement()
    {
        transform.Translate(Vector2.right * speed);
        if (onBord)
        {
            isRight = !isRight;
            if(isRight)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void FollowPLayer()
    {
        Vector2 playerPosition = player.position;
        Vector2 position = transform.position;

        float space = Vector2.Distance(position, playerPosition);
        if (space >= minDistance)
        {

            Vector2 direction = playerPosition - position;
            direction = new Vector2(direction.x, 0f);

            if ((direction.x > 0) & (!isRight))
            {
                isRight = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if ((direction.x < 0) & (isRight))
            {
                isRight = false;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (!onBord)
                transform.Translate(Vector2.right * speed);
        }
    }
}
