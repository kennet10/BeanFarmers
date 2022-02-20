using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


//Made by Ben Hamilton

public class AnimalAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject pursuer;
    [SerializeField] private TextMeshPro SleepingText;
    [SerializeField] private float FleeDistance = 5.0f;
    [SerializeField] private float WanderRadius = 5.0f;
    [SerializeField] private float WanderChance = 0.5f;
    [SerializeField] private float WanderTime = 3.0f;
    [SerializeField] private float SleepTime = 5.0f;

    private bool acting = false;

    private void Start()
    {

    }

    private void Awake()
    {
        SleepingText.enabled = false;
    }

    private void Update()
    {
        /*

        // FLEE

        // check to see if pursuer is close enough to flee from
        float DistanceFromPursuer = Vector3.Distance(transform.position, pursuer.transform.position);

        Debug.Log($"{transform.position}, {pursuer.transform.position}, {DistanceFromPursuer}");
        
        if (DistanceFromPursuer < FleeDistance)
        {
            Debug.Log("Fleeing");
            acting = true;
            Flee();
        }

        */

        
        /*
        
        // as long as it's not fleeing, either sleep or wander

        if (!acting)
        {
            float randomChance = Random.Range(0f, 1f);
            Debug.Log($"Random Number: {randomChance}");

            // WANDER
            if (randomChance <= WanderChance)
            {
                Debug.Log("Wandering");
                acting = true;
                StartCoroutine(Wander());
            }

            // SLEEPING
            if (randomChance >= WanderChance)
            {
                Debug.Log("Sleeping");
                acting = true;
                StartCoroutine(Sleep());
            }
        }
        */
    }

    IEnumerator Sleep()
    {
        SleepingText.enabled = true;
        yield return new WaitForSeconds(SleepTime);
        SleepingText.enabled = false;

        acting = false;
        Debug.Log("Sleep End");
    }

    private void Flee()
    {
        Vector3 DirToPursuer = transform.position - pursuer.transform.position;

        Vector3 newPos = transform.position - DirToPursuer;

        agent.SetDestination(newPos);
        
        acting = false;
        Debug.Log("Flee End");
    }

    IEnumerator Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, 1);
        Vector3 nextPosition = hit.position;

        agent.SetDestination(nextPosition);

        yield return new WaitForSeconds(WanderTime);

        acting = false;
        Debug.Log("Wander End");
    }
}
