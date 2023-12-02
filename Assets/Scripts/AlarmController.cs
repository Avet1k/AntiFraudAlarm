using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmController : MonoBehaviour
{
    [SerializeField] private FraudDetector _detector;
    
    private AudioSource _sound;
    private float _maxVolume = 1;
    private float _changingDuration = 1;
    private float _runningTime;

    private void OnEnable()
    {
        _detector.Detected += TurnOn;
        _detector.Lost += TurnOff;
    }

    private void OnDisable()
    {
        _detector.Detected -= TurnOn;
        _detector.Lost -= TurnOff;
    }

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void TurnOn()
    {
        _runningTime = 0;
        _sound.volume = 0;
        _sound.Play();
        
        StartCoroutine(ChangeVolume(0, _maxVolume));
    }
    
    private void TurnOff()
    {
        _runningTime = 0;
        
        StartCoroutine(ChangeVolume(_maxVolume, 0));
        StartCoroutine(StopPlaying());
    }

    private IEnumerator ChangeVolume(float current, float target)
    {
        while (_sound.volume != target)
        {
            _runningTime += Time.deltaTime;
              
            float maxVolumeDelta = _runningTime / _changingDuration;
            
            _sound.volume = Mathf.MoveTowards(current, target, maxVolumeDelta);

            yield return null;
        }
    }
    
    private IEnumerator StopPlaying()
    {
        yield return new WaitUntil(() => _sound.volume == 0);
        
        _sound.Stop();
    }
}
