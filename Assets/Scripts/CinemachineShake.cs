using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera _virtualCamera;
    private float _shakeTimer;
    private float _startingIntensity;
    private float _shakeTimerTotal;
    private PlayerMovementController _player;

    private void Awake()
    {
        Instance = this;
        _player = FindAnyObjectByType<PlayerMovementController>();
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time) 
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        _player.Jump(300f);

        _startingIntensity = intensity;
        _shakeTimerTotal = time;
        _shakeTimer = time;
    }

    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;            
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                Mathf.Lerp(_startingIntensity, 0f, 1 - (_shakeTimer / _shakeTimerTotal));           
        }           
    }
}
