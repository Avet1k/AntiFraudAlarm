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
    private float _raisingDuration = 1;
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
        _sound.volume = 0;
        _sound.Play();
        
        StartCoroutine(VolumeIncrease());
    }

    private IEnumerator VolumeIncrease()
    {
        while (_sound.volume < _maxVolume)
        {
            _runningTime += Time.deltaTime;
              
            float maxVolumeDelta = _runningTime / _raisingDuration;
            
            _sound.volume = Mathf.MoveTowards(0, _maxVolume, maxVolumeDelta);

            yield return null;
        }
    }
}
