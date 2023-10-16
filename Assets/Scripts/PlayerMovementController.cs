using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 400f;

    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3 (horizontal, 0);

        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetKeyDown("space") && _characterGrounding.IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
