using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Respawn
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    //Player Life
    public GameObject[] hearts;
    public int life;

    void Start()
    {
        checkpointPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }

    //Respawner
    //Needs a gameObject with tags: Respawn, Checkpoint.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            checkpointPos = collision.transform.position;

            SpriteRenderer checkpointRenderer = collision.GetComponent<SpriteRenderer>();
            if (checkpointRenderer != null)
            {
                checkpointRenderer.sprite = active;
            }
        }
        else if (collision.CompareTag("Respawn"))//When player triggers something with the tag Respawn, it is teleported to the last touched checkpoint
        {
            transform.position = checkpointPos; 
            takeDamage(1);
        }
    }

    public void takeDamage(int d)
    {
        life -= d;
    }
}
