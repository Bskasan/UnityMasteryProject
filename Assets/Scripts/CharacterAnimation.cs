using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private IMove _mover;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<IMove>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = _mover.Speed;
        _animator.SetFloat("Speed", Mathf.Abs(speed));

        if(speed != 0)
            _spriteRenderer.flipX = speed > 0; 
    }
}
