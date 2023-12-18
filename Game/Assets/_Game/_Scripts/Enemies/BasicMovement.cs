using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.03f;
    [SerializeField] private float distance = 1;
    [SerializeField] private bool isRight = true;
    private bool seePlayer = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerlayer;

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
        if(!seePlayer)
            transform.Translate(Vector2.right * speed);
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
            Vector2 playerPosition = player.position;
            Vector2 direction = playerPosition - position;
            RaycastHit2D hit = Physics2D.Raycast(position, direction.normalized);
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Encontrou o player");
                }
                else
                {
                    Debug.Log(hit.transform.name);
                    Debug.Log("Player na area, mas algo atrapalha");
                }
            }
            seePlayer = true;
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
            isRight = !isRight;
            if(isRight)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
