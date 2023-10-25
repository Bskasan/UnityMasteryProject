using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disableSprite;
    [SerializeField] private int _totalCoins = 3;

    private int _remainingCoins;

    private void Awake()
    {
        _remainingCoins = _totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerMovementController>();
        if (player != null && _remainingCoins > 0 && collision.contacts[0].normal.y > 0.5) 
        {
            // Code for collision with player
            GameManager.Instance.AddCoin();
            _remainingCoins--;

            if (_remainingCoins <= 0)
            {
                _enabledSprite.enabled = false;
                _disableSprite.enabled = true;
            }
        }
    }
}
