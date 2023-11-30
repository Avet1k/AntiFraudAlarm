using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FraudLeaving : MonoBehaviour
{
    [SerializeField] private UnityEvent _left;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Fraud _))
            _left.Invoke();
    }
}
