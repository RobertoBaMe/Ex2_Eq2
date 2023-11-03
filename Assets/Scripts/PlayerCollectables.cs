using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Collectable")) { 
            //TODO: Aumentar vida o contador en la UI
            collision.gameObject.SetActive(false);
        }
    }
}
