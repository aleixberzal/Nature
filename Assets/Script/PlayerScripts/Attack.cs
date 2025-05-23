using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 1.0f;
    public LayerMask enemyMask;

    public int attackDamage = 25;
    public float cooldown = .5f;
    private float cooldownTimer = 0f;
    private void Update()
    {
        if (cooldownTimer <= 0f)
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);

                foreach (var enemy in enemiesInRange)
                {
                    Destroy(enemy.gameObject);
                }
                cooldownTimer = cooldown;
            }
        }
        else { 
            cooldownTimer -= Time.deltaTime;
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}
