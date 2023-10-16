using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 400f;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3 (horizontal, 0);

        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetButtonDown("Fire1"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
