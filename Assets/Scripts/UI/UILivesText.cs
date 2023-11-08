using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TMP_Text tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        tmproText.text = GameManager.Instance.Lives.ToString();
    }

    // Call the event when only live changed.
    private void HandleOnLivesChanged(int livesRemaining)
    {
        tmproText.SetText($"x {livesRemaining.ToString()}");
    }
}
