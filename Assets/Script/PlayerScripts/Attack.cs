using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool attack = false;
    float timeBetweenAttack = 0.5f; // medio segundo entre ataques
    float timeSinceAttack = 0;

    public Transform sideTransform, upTransform, downTransform;
    public Vector2 sideArea, upArea, downArea;
    public LayerMask enemyLayer;

    private float yAxis, xAxis;

    void Update()
    {
        GetInputs();
        AttackInput();
    }

    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
    }

    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            attack = true;
            AttackAction();
           
        }
        else
        {
            attack = false;
        }
    }

    void AttackAction()
    {
        timeSinceAttack += Time.deltaTime;

        if (attack && timeSinceAttack >= timeBetweenAttack)
        {
            timeSinceAttack = 0;


            if (yAxis == 0 || xAxis != 0)
            {
            
                Hit(sideTransform, sideArea);
            }
            else if (yAxis > 0)
            {
                Hit(upTransform, upArea);
            }
            else if (yAxis < 0)
            {
                Hit(downTransform, downArea);
            }
        }
    }

    private void Hit(Transform attackTransform, Vector2 attackArea)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(attackTransform.position, attackArea, 0);
        foreach (Collider2D hit in hits)
        {
            Debug.Log("Golpeado: " + hit.name);
            Destroy(hit.gameObject);
        }
    }



 

}
