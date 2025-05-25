using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed = 2f;

    public bool waitAtPoints = false;
    public float waitTime = 1.0f;

    private Vector3 targetPos;
    private float waitTimer = 0f;
    private bool isWaiting = false;

    void Start()
    {
        targetPos = posA.position;
    }

    void Update()
    {
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
            }
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            if (targetPos == posA.position)
                targetPos = posB.position;
            else
                targetPos = posA.position;

            if (waitAtPoints)
            {
                isWaiting = true;
                waitTimer = waitTime;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
