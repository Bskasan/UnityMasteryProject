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
        if (collision.WasHitByPlayer() && _remainingCoins > 0 && collision.WasBottom())
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


}
