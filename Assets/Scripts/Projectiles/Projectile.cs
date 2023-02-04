using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _distance;

    [SerializeField]
    private float _speed;
    [SerializeField, Range(1, 250)]
    private float _firingRange = 2;
    [SerializeField]
    private float _damage;

    //private void Start() 
    //    => StartCoroutine(DestructionBullet());

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * transform.forward;
        _distance = Vector3.Distance(transform.position, transform.parent.position);

        if (_distance >= _firingRange) Destroy(gameObject);
    }

    //private IEnumerator DestructionBullet()
    //{
    //    yield return new WaitForSeconds(_firingRange);
    //    Destroy(gameObject);
    //}
}
