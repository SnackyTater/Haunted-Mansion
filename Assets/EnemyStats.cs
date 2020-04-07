using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public int maxShield = 100;
    int currentShield;


    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
    }

    public void TakeDamage(int damage, int shieldDamage)
     {
        Debug.Log("currentshield" + currentShield);
        Debug.Log("currenthealth" + currentHealth);

        if (currentShield > 0)
        {
            if(shieldDamage > 0)
            {
                // chạy animation nhận dmg vào shield
                currentShield-=shieldDamage;
            }
            else
            {
                //chạy animation vỡ shield nếu có
                Debug.Log("shield = gone");
            }
        } 
        else
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    

    void Die()
    {

        Debug.Log("Die");
        GetComponent<Collider2D>().enabled = false; // tắt collider để player di chuyển qua
        //có thể chạy thêm animation biến mất của enemy (hoặc chết)
        this.enabled = false;

    }
}
