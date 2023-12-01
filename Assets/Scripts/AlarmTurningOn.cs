using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmTurningOn : MonoBehaviour
{
    [SerializeField] private FraudDetecting _detector;
    
    private AudioSource _sound;
    private float _maxVolume = 1;
    private float _raisingDuration = 2;
    private float _runningTime;

    private void OnEnable()
    {
        _detector.Detected += TurnOn;
    }

    private void OnDisable()
    {
        _detector.Detected -= TurnOn;
    }

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void TurnOn()
    {
        _sound.Play();
        StartCoroutine(VolumeIncrease());
    }

    private IEnumerator VolumeIncrease()
    {
        _sound.volume = 0;
        _runningTime += Time.deltaTime;
     
        float maxVolumeDelta = _runningTime / _raisingDuration;
        
        while (_sound.volume < _maxVolume)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, _maxVolume, maxVolumeDelta);

            yield return null;
        }
    }
}
