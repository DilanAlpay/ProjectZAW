using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : MonoBehaviour
{
    public float radius = 12.5f;
    public LayerMask targets;
    private NavMeshAgent agent;
    private Transform target =null;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            //Look for something to chase
            Collider[] hits = Physics.OverlapSphere(transform.position, radius, targets);
            if (hits.Length > 0)
            {
                target = hits[0].transform;
                agent.isStopped = false;
            }
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
