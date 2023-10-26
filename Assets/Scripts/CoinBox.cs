using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disableSprite;
    [SerializeField] private int _totalCoins = 3;

    private int _remainingCoins;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _remainingCoins = _totalCoins;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (WasHitByPlayer(collision) && CheckRemainingCoins() && WasHitFromBottomSide(collision))
        {
            // Code for collision with player
            GameManager.Instance.AddCoin();
            _remainingCoins--;
            _animator.SetTrigger("FlipCoin");

            if (_remainingCoins <= 0)
            {
                _enabledSprite.enabled = false;
                _disableSprite.enabled = true;
            }
        }
    }

    private bool CheckRemainingCoins()
    {
        return _remainingCoins > 0;
    }

    private static bool WasHitByPlayer(Collision2D collision)
    {         
        return collision.collider.GetComponent<PlayerMovementController>(); ;
    }

    private static bool WasHitFromBottomSide(Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }
}
