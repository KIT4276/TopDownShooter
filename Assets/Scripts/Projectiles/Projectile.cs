using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _distance;
    private Collider _collider;

    [SerializeField]
    private float _speed;
    [SerializeField, Range(1, 250)]
    private float _minFiringRange = 1;
    [SerializeField, Range(1, 250)]
    private float _maxFiringRange = 10;
    [SerializeField]
    private float _damage;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * transform.forward;
        _distance = Vector3.Distance(transform.position, transform.parent.position);

        if (_distance >= _minFiringRange) _collider.isTrigger = true;
        if (_distance >= _maxFiringRange) Destroy(gameObject);
    }
}
