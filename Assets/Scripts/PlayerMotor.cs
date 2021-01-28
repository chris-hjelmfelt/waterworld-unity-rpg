using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            // Debug.Log("Target is " + target.name + " and distance is " + agent.remainingDistance);
        }
    }

    // Update is called once per frame
    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;        
        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        target = null;
    }
}
