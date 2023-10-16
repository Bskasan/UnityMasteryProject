using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private bool isGrounded;

    private void Update()
    {
        ChekcFootForGrounding(_leftFoot);
        if(isGrounded == false)
            ChekcFootForGrounding(_rightFoot);

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
            isGrounded = true;
        else
            isGrounded = false;
    }
}
