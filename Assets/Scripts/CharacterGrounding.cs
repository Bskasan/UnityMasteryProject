using System;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    // ? -> Our variable could also be a null.
    private Transform _groundedObject;
    private Vector3? _groundedObjectLastPosition;

    // Setting private, but getting public
    public bool IsGrounded { get; private set; }
    

    private void Update()
    {
        ChekcFootForGrounding(_leftFoot);
        if(IsGrounded == false)
            ChekcFootForGrounding(_rightFoot);

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

    private void ChekcFootForGrounding(Transform foot)
    {
        if (foot == null)
            return;

        var raycastHit = Physics2D.Raycast(
                    foot.position,
                    Vector2.down,
                    maxDistance,
                    layerMask);

        Debug.DrawRay(_leftFoot.position, Vector3.down * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
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
