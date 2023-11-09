using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private Animator _animator = null;
    private PlayerAudio _audio = null;

    [SerializeField] private GameObject _sword = null;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<PlayerAudio>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_sword != null && collision.gameObject.CompareTag("Sword") && !_sword.activeInHierarchy) { 
            collision.gameObject.SetActive(false);
            _sword.SetActive(true);
        }
    }

    public void Attack(){
        if (_sword.activeInHierarchy) {
            _animator.Play("Attack");
            _audio.PlayOneShot(0);
            UnityEngine.Debug.Log("Attack");
        }
    }

}
