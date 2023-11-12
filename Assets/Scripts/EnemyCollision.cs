using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        EnemyHealth enemyhealth = hit.GetComponent<EnemyHealth>();

        if (enemyhealth != null)
        {
            enemyhealth.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}

