using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmTurningOff : MonoBehaviour
{
    [SerializeField] private FraudLeaving _detector;
    
    private AudioSource _sound;
    private float _maxVolume = 1;
    private float _raisingDuration = 1;
    private float _runningTime;

    private void OnEnable()
    {
        _detector.Lost += TurnOff;
    }

    private void OnDisable()
    {
        _detector.Lost -= TurnOff;
    }

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void TurnOff()
    {
        StartCoroutine(VolumeDecrease());
        StartCoroutine(StopPlaying());
    }

    private IEnumerator VolumeDecrease()
    {
        while (_sound.volume > 0)
        {
            _runningTime += Time.deltaTime;
         
            float maxVolumeDelta = _runningTime / _raisingDuration;
            
            _sound.volume = Mathf.MoveTowards(_maxVolume, 0, maxVolumeDelta);

            yield return null;
        }
    }

    private IEnumerator StopPlaying()
    {
        yield return new WaitUntil(() => _sound.volume == 0);
        
        _sound.Stop();
    }
} 

