using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;


namespace _Game._Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IDamageble))]
    [RequireComponent(typeof(Stats))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;
        private InputAction move;
        private InputAction jump;
        
        private Rigidbody2D rigidBody;

        private float axis = 0;

        [SerializeField] private float speed = 10f;
        
        private Vector3 velocity;
        
        [SerializeField] private float movementSmoothing = .5f;

        [SerializeField] private LayerMask groundLayer;

        private Transform groundCheckTransform;
        
        private bool canJump = true;
        
        [SerializeField] private float jumpHeight = 60f;

        private IDamageble damageable;
        
        // Start is called before the first frame update
        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            
            rigidBody = GetComponent<Rigidbody2D>();

            groundCheckTransform = transform.GetChild(1).GetComponent<Transform>();

            damageable = GetComponent<IDamageble>();
            damageable.DamageEvent += onDamage;
        }

        private void OnDestroy()
        {
            if (damageable != null)
                damageable.DamageEvent -= onDamage;
        }

        private void FixedUpdate()
        {
            GroundCheck();
            Move();
        }

        // Update is called once per frame
        private void Update()
        {
            axis = move.ReadValue<Vector2>().normalized.x;
        }

        private void Move()
        {
            Vector3 targetVelocity = new Vector2(axis * speed, rigidBody.velocity.y);

            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);
        }

        private void GroundCheck()
        {
            canJump = false;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckTransform.position, .02f, groundLayer);
            
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
            move = playerInputActions.Player.Move;
            move.Enable();

            jump = playerInputActions.Player.Jump;
            jump.Enable();
            jump.performed += Jump;
        }

        private void OnDisable()
        {
            move.Disable();
            jump.Disable();
        }

        private void onDamage()
        {
            
        }
    }
}
