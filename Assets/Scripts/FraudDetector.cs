using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FraudDetector : MonoBehaviour
{
    public event UnityAction Detected;
    public event UnityAction Lost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fraud _))
            Detected?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Fraud _))
            Lost?.Invoke();
    }
}
