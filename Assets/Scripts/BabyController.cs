// Credits to Brackeys on Youtube
// https://youtu.be/xppompv1DBg?si=asYAMC5m9KGn_r6I
// and
// JonDevTutorials on Youtube
// https://www.youtube.com/watch?v=dYs0WRzzoRc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabyController : MonoBehaviour
{
    public float lookRadius = 8;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // wander around
        if(agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(GetComponent<Transform>().position, 5, out point)) //pass in our centre point and radius of area
            {
                agent.SetDestination(point);
            }
        }

        // turn to face the player & chase once close enough
        float distFromPlayer = Vector3.Distance(target.position, transform.position);
        if (distFromPlayer <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distFromPlayer <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    // rotate baby to face player
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // get a random point around the baby then do a navmesh raycast 
    bool RandomPoint(Vector3 origin, float range, out Vector3 result)
    {
        Vector3 randomPoint = origin + (Random.insideUnitSphere * range);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
