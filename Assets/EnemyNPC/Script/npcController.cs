using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class npcController : MonoBehaviour
{
    
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    

    public float maxRoamDistance;

    public int characterState;
    private float horizontal, vertical;
    private float RoamTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
     
    }

    void Update()
    {
        animations();
        Roam();
    }

    void Roam()
    {
        if (characterState != 0) return;

        if (Time.time > RoamTimer)
        {
            float a = Random.Range(0, 2);
            RoamTimer = Time.time + 20;
            navMeshAgent.SetDestination(new Vector3(transform.position.x + Random.Range(maxRoamDistance/2, maxRoamDistance) * (a == 1 ? 1 : -1), 0
            , transform.position.z + Random.Range(maxRoamDistance/2, maxRoamDistance) * (a == 1 ? 1 : -1)));
        }


    }

    void animations()
    {
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("horizontal", horizontal);
        animator.SetInteger("state", characterState);
    }

    

    string getCharState()
    {
        switch (characterState)
        {
            case 0:
                return "peaceful";
            case 1:
                return "Combat";
        }
        return "out of range";

    }

}
