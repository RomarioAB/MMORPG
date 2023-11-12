using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public const int maxHealth = 50;
    public int currentHealth = maxHealth;
    public bool destroyOnDeath;


    public void TakeDamage(int amount)
    {
        
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }

            Debug.Log("Dead");
        }

    }

}