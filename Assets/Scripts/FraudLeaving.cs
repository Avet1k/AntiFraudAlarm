using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FraudLeaving : MonoBehaviour
{
    public event UnityAction Lost;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Fraud _))
            Lost?.Invoke();
    }
}
