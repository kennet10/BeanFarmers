using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject pursuer;
    [SerializeField] private float FleeDistance = 5.0f;
    [SerializeField] private float WanderRadius = 5.0f;

    private bool acting = false;

    private System.Timers.Timer aTimer;

    private void Start()
    {
        Wander();
    }

    private void Update()
    {
        /* SLEEPING
        {
            Bring Up UI ZZZs
            Wait
        }
        */


        /* WANDER
        if (!acting)
        {
            Debug.Log("Ping 1");
            acting = true;
            Wander();
        }
        */

        // FLEE

        /*
        //check to see if pursuer is close enough to flee from
        float DistanceFromPursuer = Vector3.Distance(transform.position, pursuer.transform.position);
        Debug.Log($"{transform.position}, {pursuer.transform.position}, {DistanceFromPursuer}");
        if (DistanceFromPursuer < FleeDistance)
        {
            Debug.Log("AHHHH EVERYBODY PANIC");
            Flee();
        }
        */
    }

    /*
    private void Flee()
    {
        Vector3 DirToPursuer = transform.position - pursuer.transform.position;

        Vector3 newPos = transform.position - DirToPursuer;

        agent.SetDestination(newPos);
    }
    */

    private void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, 1);
        Vector3 nextPosition = hit.position;

        agent.SetDestination(nextPosition);

        

        acting = false;
        Debug.Log("Ping 2");
    }
}
