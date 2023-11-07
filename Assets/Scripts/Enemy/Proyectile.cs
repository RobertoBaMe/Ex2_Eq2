using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private float speed; //Velovidad del proyectil
    private Transform player; //referencia al transform del jugador
    private Rigidbody2D rb;
    [SerializeField]private AudioSource ads;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        ads = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        LaunchProyectile();
    }
    private void LaunchProyectile()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.velocity = directionToPlayer * speed;
        StartCoroutine(DestroProjectile());
    }
    IEnumerator DestroProjectile()      //Destrulle el projectil despues de 5 segundos
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ads.Play();
        Destroy(gameObject);
    }
}
