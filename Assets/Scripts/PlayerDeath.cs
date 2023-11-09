using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator _animator = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Death() {
        _animator.Play("Death");
    }
}
