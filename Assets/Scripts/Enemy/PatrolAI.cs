using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform[] waypoints;

    private int currentWayPoints;
    private bool isWaiting;

    // Update is called once per frame
    void Update()
    {
        if(transform.position != waypoints[currentWayPoints].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPoints].position, speed * Time.deltaTime);
        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWayPoints++;
        if(currentWayPoints == waypoints.Length)
        {
            currentWayPoints = 0;
        }
        isWaiting = false;
        Flip();
    }
    
    private void Flip()
    {
        if(transform.position.x > waypoints[currentWayPoints].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
