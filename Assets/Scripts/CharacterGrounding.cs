using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private int layerMask;

    private bool isGrounded;

    private void Update()
    {
        var raycastHit = Physics2D.Raycast(
            _leftFoot.position,
            Vector2.down,
            maxDistance,
            layerMask);

        if (raycastHit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false; 
        }
    }
}
