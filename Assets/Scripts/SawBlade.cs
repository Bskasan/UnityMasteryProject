using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _sawBladeSprite;
    [SerializeField] private float _speed;

    private float _positionPercent;
    private int _direction = 1;

    private void Update()
    {
        float distance = Vector3.Distance(_start.position, _end.position);
        float speedForDistance = _speed / distance;

        _positionPercent += Time.deltaTime * _direction * speedForDistance;

        _sawBladeSprite.position = Vector3.Lerp(_start.position, _end.position, _positionPercent);

        if (_positionPercent >= 1 && _direction == 1)
        {
            _direction = -1;
        }
        else if (_positionPercent <= 0 && _direction == -1)
        {
            _direction = 1;
        }

    }
}
