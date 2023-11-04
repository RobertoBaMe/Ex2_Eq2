using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private GameObject _sword = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_sword != null && collision.gameObject.CompareTag("Sword") && !_sword.activeInHierarchy) { 
            collision.gameObject.SetActive(false);
            _sword.SetActive(true);
        }
    }

}
