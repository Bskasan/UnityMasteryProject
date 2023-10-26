using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Lambda Expressions
        GameManager.Instance.OnCoinsChanged += (coins) => _audioSource.Play();
    }
}
