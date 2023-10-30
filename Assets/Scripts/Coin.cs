using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pMovementController = collision.GetComponent<PlayerMovementController>();
        if (pMovementController != null)
        {
            GameManager.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
