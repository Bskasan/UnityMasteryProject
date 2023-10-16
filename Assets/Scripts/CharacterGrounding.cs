using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private bool isGrounded;

    private void Update()
    {
        var raycastHit = Physics2D.Raycast(
            _leftFoot.position,
            Vector2.down,
            maxDistance,
            layerMask);

        Debug.DrawRay(_leftFoot.position, Vector3.down * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            isGrounded = true;
            Debug.Log($"Grounding is => {isGrounded}");
        }
        else
        {
            isGrounded = false;
            Debug.Log($"Grounding is => {isGrounded}");
        }
    }
}
