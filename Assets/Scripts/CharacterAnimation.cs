using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private IMove mover;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = mover.Speed;
        _animator.SetFloat("Speed", speed);
    }
}
