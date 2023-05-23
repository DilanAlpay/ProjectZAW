using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chaser : EnemyBehaviour
{
    private NavMeshAgent agent;

    public override void Activate(Player p)
    {
        base.Activate(p);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
           agent.SetDestination(target.transform.position);
        }
    }
}
