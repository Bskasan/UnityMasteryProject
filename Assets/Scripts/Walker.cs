using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + _direction * _speed);
    }
}
