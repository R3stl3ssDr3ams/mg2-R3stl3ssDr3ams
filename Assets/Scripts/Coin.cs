using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _coinTF;

    private void Update()
    {
        if (_coin != null)
        {
            _coinTF.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _collided = collision.gameObject;
        if (_collided.CompareTag("Player") || _collided.CompareTag("Collider"))
        {
            Destroy(_coin);
        }
    }
}
