using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [FormerlySerializedAs("sawBladeSprite")]
    [SerializeField] private Transform _sprite;
    [SerializeField] private float _speed;

    private float _positionPercent;
    private int _direction = 1;

    private void Update()
    {
        float distance = Vector3.Distance(_start.position, _end.position);
        float speedForDistance = _speed / distance;

        _positionPercent += Time.deltaTime * _direction * speedForDistance;

        _sprite.position = Vector3.Lerp(_start.position, _end.position, _positionPercent);

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
