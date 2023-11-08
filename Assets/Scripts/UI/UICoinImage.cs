using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += Pulse;
    }

    // Event Deregistration
    // Do not forget to deregistrate!
    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Pulse;  
    }

    private void Pulse(int coins) => _animator.SetTrigger("Pulse");
    

}
