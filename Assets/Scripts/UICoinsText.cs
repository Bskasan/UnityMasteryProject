using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoinsText : MonoBehaviour
{
    private TMP_Text tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TMP_Text>();
    }
        
    void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;
    }

    private void HandleOnCoinsChanged(int coins)
    {
        tmproText.SetText($" {coins.ToString()}");
    }
}
