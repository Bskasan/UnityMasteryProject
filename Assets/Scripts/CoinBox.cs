using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disableSprite;
    [SerializeField] private int _totalCoins = 1;

    private int _remainingCoins;

    private void Awake()
    {
        _remainingCoins = _totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerMovementController>();
        if (player != null) 
        {
            // Code for collision with player

        }
    }
}