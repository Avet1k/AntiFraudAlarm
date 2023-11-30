using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmTurningOn : MonoBehaviour
{
    private AudioSource _alarm;
    private float _maxVolume = 1;
    private float _raisingDuration = 1;
    private float _runningTime;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.Play();
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        
        float maxVolumeDelta = _runningTime / _raisingDuration;
        
        _alarm.volume = Mathf.MoveTowards(0, _maxVolume, maxVolumeDelta);
    }
}
