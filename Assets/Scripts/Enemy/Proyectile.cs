using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private float speed; //Velovidad del proyectil
    private Transform player; //referencia al transform del jugador
    private Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();
        LaunchProyectile();
    }
    private void LaunchProyectile()
    {
        rb.velocity = Vector2.left * speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
