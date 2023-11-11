using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAi : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;       //Referencia al pryectil Prefab
    [SerializeField] private GameObject PointShoot;             //Punto de disparo
    [SerializeField] private float TimeBetweenShots;        //Tiempo de disparo o cadencia
    private AudioSource ads;
    private bool shoot = false;
    private float _timeStart = 0;
    private void Awake()
    {
        ads = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _timeStart = TimeBetweenShots;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shoot = true;
            if (_timeStart <= 0)
            {
                _timeStart = TimeBetweenShots;
                Instantiate(proyectilePrefab, new Vector3(PointShoot.transform.position.x, PointShoot.transform.position.y, 0), Quaternion.identity);
                UnityEngine.Debug.Log("Shoot");
                ads.Play();
            }
        }
        else {
            shoot = false;
        }
    }

    private void Update()
    {
        _timeStart -= Time.deltaTime;        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Sword"))
        {            
            Destroy(gameObject);
        }
    }
}
