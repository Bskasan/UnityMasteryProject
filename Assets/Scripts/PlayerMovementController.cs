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
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;
        
        Vector3 movement = new Vector3 (horizontal, 0);

        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetKeyDown("space") && _characterGrounding.IsGrounded)
        {
            Jump();
        }
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
