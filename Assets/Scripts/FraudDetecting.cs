using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FraudDetecting : MonoBehaviour
{
    [SerializeField] private UnityEvent _detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fraud _))
            _detected?.Invoke();
    }
}
