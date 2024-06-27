using System;
using _Game._Scripts.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game._Scripts.Enemies
{
    public class BasicMovement : MonoBehaviour
    {
        private Rigidbody2D rig;

        [Header("Vision")] [SerializeField] private Vector2 rangeVision = new Vector2(4, 3);

        [Header("Movimento")] [SerializeField] private float speed = 0.03f;
        [SerializeField] private float atkDistance;

        [Header("Components")] [SerializeField]
        private Transform groundCheck;
        private Transform obstacleCheck;

        [SerializeField] private Transform player;
        [SerializeField] private Stats stats;
        [SerializeField] private LayerMask playerlayer;
        [SerializeField] private LayerMask groundLayer;

        [Header("Tests")] private bool isRight = true;
        [SerializeField] private bool seePlayer = false;
        private bool onBord = false;
        private bool onObstacle = false;

        // Start is called before the first frame update
        void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            stats = GetComponent<Stats>();
            groundCheck = transform.GetChild(0).GetComponent<Transform>();
            obstacleCheck = transform.GetChild(1).GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            if (seePlayer)
                FollowPLayer();
            else
                Movement();
        }

        // Update is called once per frame
        void Update()
        {
            DetectBorder();

            DetectObstacles();

            FindPlayer();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, rangeVision);
            if (seePlayer)
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
                RaycastHit2D[] hit = Physics2D.RaycastAll(position, direction.normalized);
                RaycastHit2D target = hit[1];
                if (target.transform != null)
                {
                    Debug.Log(target.transform.name);
                    if (target.transform.CompareTag("Player"))
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
            RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, 1, groundLayer);

            if (!ground.collider)
            {
                onBord = true;
            }
            else
            {
                onBord = false;
            }
        }

        private void DetectObstacles()
        {
            Vector2 vc;
            if (isRight)
                vc = Vector2.right;
            else
                vc = Vector2.left;
            RaycastHit2D obstacle = Physics2D.Raycast(obstacleCheck.position, vc, 0.4f, groundLayer);

            if (obstacle.collider)
                onObstacle = true;
            else
                onObstacle = false;
        }

        private void Movement()
        {
            transform.Translate(Vector2.right * speed);
            if (onBord || onObstacle)
            {
                Spin();
            }
        }

        private void Spin()
        {
            isRight = !isRight;
            if (isRight)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 180, 0);
        }

        private void FollowPLayer()
        {
            Vector2 playerPosition = player.position;
            Vector2 position = transform.position;

            float space = Vector2.Distance(position, playerPosition);
            if (space >= atkDistance)
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
}
