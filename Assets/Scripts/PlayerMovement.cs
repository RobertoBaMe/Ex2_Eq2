using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb = null;
    private float _horizontal = 0f;
    private PlayerAudio _audio = null;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private VariableJoystick _joystick = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<PlayerAudio>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void Move(float horizontal) {
        transform.Translate(horizontal * _speed * Time.deltaTime, 0, 0);
        if (horizontal != 0 && Mathf.Abs(_rb.velocity.y) < 0.001f) _audio.PlaySteps(1);
        if (horizontal > 0 && _spriteRenderer.flipX) _spriteRenderer.flipX = false;
        if (horizontal < 0 && !_spriteRenderer.flipX) _spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        Move(_horizontal);
        Move(_joystick.Horizontal);
    }

    public void Jump() {
        if (Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _audio.PlayOneShot(2);
        }

    }
}
