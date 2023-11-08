using System;
using UnityEngine;


// We must have Character Grounding
[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private float _wallJumpForce = 300f;

    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;
    

    public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && _characterGrounding.IsGrounded)
        {
            Jump(_jumpForce);

            // Checkin the Grounding Direction 
            if (_characterGrounding.GroundedDirection != Vector2.down)
            {
                // Jumping to the opposite direction
                _rigidbody2D.AddForce(_characterGrounding.GroundedDirection * -1f * _wallJumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;
        
        Vector3 movement = new Vector3 (horizontal, 0);

        transform.position += movement * Time.deltaTime * _moveSpeed;       
    }

    internal void Bounce()
    {
        Jump(200f);
    }

    public void Jump(float jumpForce)
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce);      
    }

    
}
