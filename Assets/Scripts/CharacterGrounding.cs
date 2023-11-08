using System;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    // ? -> Our variable could also be a null.
    private Transform _groundedObject;
    private Vector3? _groundedObjectLastPosition;

    // Setting private, but getting public
    public bool IsGrounded { get; private set; }
    

    private void Update()
    {
        foreach (var position in _positions)
        { 
            CheckFootForGrounding(position);
            if (IsGrounded)
                break;
        }

        StickToMovingObjects();

    }

    private void StickToMovingObjects()
    {
        if (_groundedObject != null)
        {
            if (_groundedObjectLastPosition.HasValue && 
                _groundedObjectLastPosition.Value != _groundedObject.position)
            {
                Vector3 delta = _groundedObject.position - _groundedObjectLastPosition.Value;
                transform.position += delta;
            }

            _groundedObjectLastPosition = _groundedObject.position;
        }
        else
        {
            _groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        if (foot == null)
            return;

        var raycastHit = Physics2D.Raycast(
                    foot.position,
                    Vector2.down,
                    maxDistance,
                    layerMask);

        Debug.DrawRay(_positions[1].position, Vector3.down * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            if (_groundedObject != raycastHit.collider.transform)
            {               
                _groundedObjectLastPosition = raycastHit.collider.transform.position;
            }

            _groundedObject = raycastHit.collider.transform;
            IsGrounded = true;
        }
        else
        {
            _groundedObject = null;
            IsGrounded = false;
        }
    }
}   
