using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;


namespace _Game._Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rigidBody;

        private Transform sprite;

        private float axis = 0;

        [SerializeField] private float speed = 10f;
        
        private Vector3 velocity;
        
        [SerializeField] private float movementSmoothing = .5f;

        [SerializeField] private LayerMask groundLayer;

        private Transform groundCheckTransform;
        
        private bool canJump = true;
        
        [SerializeField] private float jumpHeight = 60f;

        private InputManager input;
        
        public bool right { get; private set; }
        
        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();

            sprite = transform.GetChild(0).GetComponent<Transform>();
            
            groundCheckTransform = transform.GetChild(1).GetComponent<Transform>();
            
            input = InputManager.Instance;

            right = true;
        }

        private void FixedUpdate()
        {
            GroundCheck();
            Move();
            DirectionCheck();
        }

        // Update is called once per frame
        private void Update()
        {
            axis = input.move.ReadValue<Vector2>().normalized.x;
        }

        private void Move()
        {
            Vector3 targetVelocity = new Vector2(axis * speed, rigidBody.velocity.y);

            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);
        }

        private void DirectionCheck()
        {
            switch (axis)
            {
                case -1:
                    sprite.eulerAngles = new Vector3(0, 180, 0);
                    right = false;
                    break;
                case 1:
                    sprite.eulerAngles = new Vector3(0, 0, 0);
                    right = true;
                    break;
            }
        }

        private void GroundCheck()
        {
            canJump = false;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckTransform.position, 0.5f, groundLayer);
            
            foreach (Collider2D col in colliders)
            {
                if (col.gameObject != gameObject)
                    canJump = true;
            }
        }
        
        private void Jump(InputAction.CallbackContext context)
        {
            if (canJump)
            {
                rigidBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
        }

        private void OnEnable()
        {
            input.jump.performed += Jump;
        }
    }
}
