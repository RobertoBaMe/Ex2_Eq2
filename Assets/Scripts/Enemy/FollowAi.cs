using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAi : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    private bool isFacingRight = true;
    private AnimEP animEP;
   
    private void Start()
    {
        animEP = FindObjectOfType<AnimEP>();
        player = FindObjectOfType<PlayerMovement>().transform;
        
    }

    void Update()
    {
        Follow();
        bool isplayerRight = transform.position.x < player.transform.position.x;
        Flip(isplayerRight);
    }

    private void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animEP.notAtack();
        }
        else
        {
            Attack();
        }
    }

    private void Attack()
    {
        animEP.isAtack();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Sword"))
        {
            
            Destroy(gameObject);
        }
    }

    private void Flip(bool isplayerRight)
    {
        if((isFacingRight && !isplayerRight) || (!isFacingRight && isplayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
