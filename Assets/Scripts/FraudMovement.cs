using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraudMovement : MonoBehaviour
{
    [SerializeField] private Transform _endpoint;
    private float _speed = 1f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endpoint.position,
            _speed * Time.deltaTime);
    }
}
