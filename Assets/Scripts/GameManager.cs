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
    private int currentLevelIndex;
    
   
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
            // CinemachineShake.Instance.ShakeCamera(3f, 0.5f);
        }

        if (Lives <= 0)
            RestartGame();
        else
            SendPlayerToCheckPoint();
    }

    private void SendPlayerToCheckPoint()
    {
        // Execute the code, only when Player die. ( More performance )
        var checkPointManager = FindObjectOfType<CheckpointManager>();
        var checkpoint = checkPointManager.GetLastCheckpointThatWasPassed(); 
        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;

       
    }

    internal void AddCoin()
    {
        _coins++;

        if (OnCoinsChanged != null)
            OnCoinsChanged(_coins);

        Debug.Log($"Coins : {_coins}");
    }

    public void MoveToNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void RestartGame()
    {
        Lives = 3;
        _coins = 0;

        if (OnCoinsChanged != null)
            OnCoinsChanged(_coins);

        SceneManager.LoadScene(0);
    }    
}
