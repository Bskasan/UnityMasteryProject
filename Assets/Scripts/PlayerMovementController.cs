using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float _moveSpeed = 2f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horizontal, vertical);

        transform.position += movement * Time.deltaTime * _moveSpeed;
    }
}
