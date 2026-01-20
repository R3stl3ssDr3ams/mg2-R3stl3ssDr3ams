using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jump = 1f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameController _gameController;

    private bool _isGrounded = true;
    private int _points = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) && _isGrounded == true)
        {
            _isGrounded = false;
            _rigidbody.AddForce(transform.up * _jump, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _collided = collision.gameObject;
        if (_collided.CompareTag("Coin"))
        {
            _points += 1;
            GameController _targetscript = _gameController;
            _targetscript.Score(_points);
        }
    }
}
