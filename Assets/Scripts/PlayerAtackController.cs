using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackController : MonoBehaviour
{
    [Header("Attacking")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackCooldown;

    public float meleeAttackRange;
    public int damage;
    public LayerMask enemyLayers;

    private int baseDamage;
    private float cooldownTimer = Mathf.Infinity;


    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        HandleAttackInput();
    }

    public void HandleAttackInput()
    {
        if (Input.GetMouseButtonDown(0) && (cooldownTimer >= attackCooldown))
        {
            Attack();

        }

    }

    private void Attack()
    {
        cooldownTimer = 0;
        playerAnimator.SetTrigger("playerAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, meleeAttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
