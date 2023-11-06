using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;

    private Vector2 _direction = Vector2.left;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move from current pos to desired pos.
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEdge())
            SwitchDirection();
    }
   
    private bool ReachedEdge()
    {
        throw new NotImplementedException();
    }

    private void SwitchDirection()
    {
        _direction *= -1;
    }
}
