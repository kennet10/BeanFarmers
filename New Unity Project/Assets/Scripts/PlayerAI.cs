using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Made by Ben Hamilton
public class PlayerAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject RM;
    [SerializeField] private GameObject FUI;
    [SerializeField] private Vector3 SellPoint;
    [SerializeField] private Vector3 FeedPoint;

    [SerializeField] private float WanderRadius = 5.0f;
    [SerializeField] private float WanderTime = 3.0f;

    private bool acting = false;
    private const float destinationDis = 1.5f;

    private void Start()
    {
        StartCoroutine(Sell());
    }

    private void Update()
    {
        if (!acting)
        {
            //acting = true;
            //StartCoroutine(Wander());
        }


        if (acting && Vector3.Distance(agent.destination, transform.position) <= destinationDis)
        {
            acting = false;
        }
    }

    /* If we want it to wander in its spare time, uncomment this
     * 
    // Wanders around based on the radius and distance of wanderRadius
    IEnumerator Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, 1);
        Vector3 nextPosition = hit.position;

        agent.SetDestination(nextPosition);

        yield return new WaitForSeconds(WanderTime);

        //Debug.Log("Wander End");
    }
    */

    IEnumerator Sell()
    {
        agent.destination = SellPoint;
        if (Vector3.Distance(agent.transform.position, SellPoint) <= .5)
        {
            //RM.GetComponent<ResourceManager>().SellAll();
            Debug.Log("Arrived at Sell Point");
        }

        yield return new WaitForSeconds(15);

    }

    IEnumerator Feed()
    {
        agent.destination = FeedPoint;
        if (Vector3.Distance(agent.transform.position, FeedPoint) <= .5)
        {
            FUI.GetComponent<FeedUI>().AIFeed();
            Debug.Log("Arrived at Feed Point");
        }

        yield return new WaitForSeconds(15);
    }
}
