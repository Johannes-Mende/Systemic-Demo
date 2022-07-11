using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SheepAIController : MonoBehaviour
{
    public NavMeshAgent agent;

    private NavMeshHit navHit;
    //private Transform myTransform;
    public Transform fleeTarget;
    private Vector3 runPosition;
    private Vector3 directiontofleetarget;
    public float fleeRange = 25;
    private float checkRate;
    private float nextCheck;
    private Vector3 finalPosition;
    float detectionRadius = 20;
    float fleeRadius = 10;
    Vector3 position;

    bool SheepisBurning = false;

    [Range(0, 100)] public float speed;
    [Range(0, 500)] public float walkRadius;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomNavMeshLoacation());
        }
    }

    void Update()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLoacation());
        }
    }
    public Vector3 RandomNavMeshLoacation()
    {

        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("detractor"))
        {
            
            
           fleeTarget = other.gameObject.transform;
           DetectNewObstacle(position);
/*
            directiontofleetarget = transform.position - fleeTarget.position;
            Vector3 checkPos = transform.position + directiontofleetarget;

            if (NavMesh.SamplePosition(checkPos, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
            {
                finalPosition = navHit.position;
              
            }*/

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("detractor") && SheepisBurning == false)
        {
           ResetAgent();
        }
    }

    void ResetAgent()
    {
        agent.speed = 3;
        agent.angularSpeed = 120;
        agent.ResetPath();
    }
     
    public void DetectNewObstacle(Vector3 position)
    {
        if(Vector3.Distance(position, this.transform.position) <= detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - position).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if(path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                agent.speed = 10;
                agent.angularSpeed = 200;
            }
        }
    }

    void IsSheepBurning()
    {
        SheepisBurning = true;
        DetectNewObstacle(position); 
    }
    void IsNotBurning()
    {
        SheepisBurning = false;
        ResetAgent();
    }
}

