using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FraudDetecting : MonoBehaviour
{
    public event UnityAction Detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fraud _))
            Detected?.Invoke();
    }
}
