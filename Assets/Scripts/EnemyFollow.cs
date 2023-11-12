using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent enemy;

    public Transform PlayerTarget;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemy.SetDestination(PlayerTarget.position);
    }
}
