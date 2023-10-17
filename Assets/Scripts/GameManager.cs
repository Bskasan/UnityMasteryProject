using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    private int _coins;
   
    private void Awake()
    {
        if (Instance != null)
        { 
            Destroy(gameObject); 
        }  
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            RestartGame();
        }       
    }

    internal void KillPlayer()
    {
        Lives--;

        if (OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
            CinemachineShake.Instance.ShakeCamera(3f, 0.5f);
        } 

        if (Lives <= 0)
            RestartGame();       
    }

    internal void AddCoin()
    {
        _coins++;

        if (OnCoinsChanged != null)
            OnCoinsChanged(_coins);

        Debug.Log($"Coins : {_coins}");
    }

    private void RestartGame()
    {
        Lives = 3;
        SceneManager.LoadScene(0);
    }    
}
