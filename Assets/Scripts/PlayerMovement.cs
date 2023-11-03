using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb = null;
    //private Animator _animator = null;
    private float _horizontal = 0f;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(_horizontal * _speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rb.velocity.y) < 0.001f) {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        if (_horizontal > 0 && _spriteRenderer.flipX) _spriteRenderer.flipX = false;
        if (_horizontal < 0 && !_spriteRenderer.flipX) _spriteRenderer.flipX = true; 

        //if (_horizontal > 0) _animator.SetBool("WalkR", true); else _animator.SetBool("WalkR", false);
        //if (_horizontal < 0) _animator.SetBool("WalkL", true); else _animator.SetBool("WalkL", false);
    }
}
