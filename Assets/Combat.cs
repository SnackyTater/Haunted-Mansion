using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    //player attack setting
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;

    //player attack stats
    public int AttackDamage = 40;
    public int shieldDamage = 100;
    
    
    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT" + enemy.name);
            enemy.GetComponent<EnemyStats>().TakeDamage(AttackDamage, shieldDamage);
        }
    }
    void OnDrawGizmosSelected() // ve len man hinh range attack
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
