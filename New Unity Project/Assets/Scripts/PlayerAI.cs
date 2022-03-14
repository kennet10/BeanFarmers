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
    [SerializeField] private float ActionDistance = 2.0f;
    [SerializeField] private const int FeedWhenRicherThan = 100;

    public static bool HasSellableItems = false;
    public static bool AnyAnimalsBought = false;

    private bool acting;
    private bool alreadyFed;
    private const float destinationDis = 1.5f;
    private const int waitTimer = 30;

    private void Start()
    {
        acting = false;
        alreadyFed = false;
    }

    // The AI wanders around unless it can sell something or feed an animal
    private void Update()
    {
        if (!acting) {

            StartCoroutine(Wander());

            if (HasSellableItems) {
                acting = true;
                Sell();
            } else if ((AnyAnimalsBought) && (ResourceManager.money >= FeedWhenRicherThan) && !alreadyFed) {
                acting = true;
                Feed();
            } else if (alreadyFed) {
                StartCoroutine(feedingWait());
            }
        }


        if (acting && Vector3.Distance(agent.destination, transform.position) <= destinationDis)
        {
            acting = false;
        }
    }

    // Wanders around based on the radius and distance of wanderRadius
    IEnumerator Wander()
    {
        acting = true;
        Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WanderRadius, 1);
        Vector3 nextPosition = hit.position;

        agent.SetDestination(nextPosition);

        yield return new WaitForSeconds(WanderTime);
    }

    // Sells all current resources
    private void Sell()
    {
        agent.destination = SellPoint;
        if (Vector3.Distance(SellPoint, agent.transform.position) <= ActionDistance)
        {
            RM.GetComponent<ResourceManager>().SellAll();
            HasSellableItems = false;
        }
    }

    // Attempts to feed all animals that the player has
    private void Feed()
    {
        agent.destination = FeedPoint;
        if (Vector3.Distance(FeedPoint, agent.transform.position) <= ActionDistance)
        {
            FUI.GetComponent<FeedUI>().AIFeed();
            alreadyFed = true;
        }

    }

    // Made by Haley Vlahos
    // Makes the AI player wait for the waitTimemr before attempting to feed the animals again
    private IEnumerator feedingWait()
    {
        yield return new WaitForSeconds(waitTimer);
        alreadyFed = false;
    }

}
