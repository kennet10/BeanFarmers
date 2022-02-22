using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Linq;


//Made by Ben Hamilton

public class AnimalAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<GameObject> wolves = new List<GameObject>();
    [SerializeField] private TextMeshPro SleepingText;

    [SerializeField] private float FleeDistance = 2.0f;
    [SerializeField] private float WanderRadius = 5.0f;
    [SerializeField] private float WanderChance = 0.7f;
    [SerializeField] private float WanderTime = 3.0f;
    [SerializeField] private float SleepTime = 5.0f;


    private const float destinationDis = 1.5f;

    private bool acting = false;
    private bool sleeping = false;

    private void Start()
    {
        wolves = GameObject.FindGameObjectsWithTag("Wolf").ToList();
    }

    private void Awake()
    {
        SleepingText.enabled = false;
    }

    private void Update()
    {


        // FLEE

        // check to see if pursuer is close enough to flee from
        if (!sleeping) {
            Vector3 closestWolf = findClosest(wolves);
            float DistanceFromPursuer = Vector3.Distance(transform.position, findClosest(wolves));

            //Debug.Log($"{transform.position}, {pursuer.transform.position}, {DistanceFromPursuer}");

            if (DistanceFromPursuer < FleeDistance) {
                Debug.Log("Fleeing");
                acting = true;
                Flee(closestWolf);
            }
        }


        // as long as it's not fleeing, either sleep or wander

        if (!acting && !sleeping) {
            float randomChance = Random.Range(0f, 1f);
            Debug.Log($"Random Number: {randomChance}");

            // WANDER
            if (randomChance <= WanderChance) {
                Debug.Log("Wandering");
                acting = true;
                StartCoroutine(Wander());
            } else {
                Debug.Log("Sleeping");
                acting = false;
                sleeping = true;
                StartCoroutine(Sleep());
            }
        }

        if (acting && Vector3.Distance(agent.destination, transform.position) <= destinationDis) {
            acting = false;
        }

    }

    private IEnumerator Sleep()
    {
        SleepingText.enabled = true;
        agent.SetDestination(transform.position);
        yield return new WaitForSeconds(SleepTime);
        SleepingText.enabled = false;

        //acting = false;
        sleeping = false;
        Debug.Log("Sleep End");
    }

    private void Flee(Vector3 location)
    {
        Vector3 DirToPursuer = location - transform.position;

        Vector3 newPos = transform.position - DirToPursuer;

        agent.SetDestination(newPos);


        //acting = false;
        //Debug.Log("Flee End");
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

        //acting = false;
        //Debug.Log("Wander End");
    }

    // Made by Haley Vlahos as in WolfAI
    private Vector3 findClosest(List<GameObject> theList)
    {
        // This is just a super high number so that anything will be closer and override
        Vector3 generalNum = Vector3.positiveInfinity;

        if (theList.Count > 0) {
            foreach (GameObject item in theList) {
                if (Vector3.Distance(transform.position, item.transform.position) < Vector3.Distance(transform.position, generalNum)) {
                    generalNum = item.transform.position;
                }
            }
        }

        return generalNum;
    }
}
