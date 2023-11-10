using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAi : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;       //Referencia al pryectil Prefab
    [SerializeField] private GameObject PointShoot;             //Punto de disparo
    [SerializeField] private float TimeBetweenShots;        //Tiempo de disparo o cadencia
    [SerializeField] private AudioSource ads;
    private Animator anim;
    private bool shoot = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        ads = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shoot = true;
            StartCoroutine(Shoot());

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shoot = false;
            StopCoroutine(Shoot());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Sword"))
        {
            
            Destroy(gameObject);
        }
    }
    IEnumerator Shoot()
    {
        while(shoot)
        {
            yield return new WaitForSeconds(TimeBetweenShots);
            Instantiate(proyectilePrefab, PointShoot.transform.position, Quaternion.identity);
            ads.Play();
        }
    }
}
