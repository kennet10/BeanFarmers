using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

// Made by Haley Vlahos
public class WolfAI : MonoBehaviour
{
    public static List<GameObject> animals = new List<GameObject>();

    private const int playerRange = 10;
    private const int animalRange = 15;
    private const int destinationDis = 5;
    private NavMeshAgent agent;
    private List<GameObject> players = new List<GameObject>();
    private bool seeking = false;

    private void Awake()
    {
        if (animals.Count > 0)
            animals.Clear();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
        
        // For testing with prexisting animals
        //animals = GameObject.FindGameObjectsWithTag("Animal").ToList();

    }

    // If the closest player is closer than the targetRange, wolf flees,
    // else if closest animal is closer than the targetRange, wolf target, otherwise wolf wanders around
    private void Update()
    {
        Vector3 targetAnim = findClosest(animals);
        Vector3 targetPlayer = findClosest(players);

        if (Vector3.Distance(targetPlayer, transform.position) < playerRange) {
            flee(targetPlayer);
        } else if (Vector3.Distance(targetAnim, transform.position) < animalRange) {
            seek(targetAnim);
        } else if(!seeking) {
            wander();
        }

        if(Vector3.Distance(agent.destination, transform.position) <= destinationDis) {
            seeking = false;
        }

    }

    // Wolf goes after the target location
    private void seek(Vector3 location)
    {
        seeking = true;
        agent.SetDestination(location);
        
    }

    // Wolf runs away from the target location
    private void flee(Vector3 location)
    {
        Vector3 fleeVector = location - transform.position;
        agent.SetDestination(transform.position - fleeVector);
    }

    // Wolf wanders around the area, setting seek locations based on randon distances in front of them based on the radius of a circle
    private void wander()
    {
        Vector3 wanderTarget = Vector3.zero;
        float wanderRadius = 20;
        float wanderDistance = 10;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = gameObject.transform.InverseTransformVector(targetLocal);

        seek(targetWorld);
        
    }

    // Returns the closest item in theList to the wolf
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
