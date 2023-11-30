using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTurningOff : MonoBehaviour
{
    private AudioSource _alarm;
    private float _maxVolume = 1;
    private float _raisingDuration = 1;
    private float _runningTime;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;

        float maxVolumeDelta = _runningTime / _raisingDuration;

        _alarm.volume = Mathf.MoveTowards(_maxVolume, 0, maxVolumeDelta);

        if (_alarm.volume == 0)
            _alarm.Stop();
    }
} 

