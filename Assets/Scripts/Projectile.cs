using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField, Range(5, 250)]
    private float _lifetime = 5;

    private void Start() 
        => StartCoroutine(DestructionBullet());

    private void Update()
        => transform.position += _speed * Time.deltaTime * transform.forward;

    private IEnumerator DestructionBullet()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }
}
