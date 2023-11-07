using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFlipped : MonoBehaviour
{

    [SerializeField] private float _shellSpeed = 5f;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;
    
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            if (_direction.magnitude == 0) // if it's not moving
            {
                LaunchShell(collision);
            }
        }
    }

}
