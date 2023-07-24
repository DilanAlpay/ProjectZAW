using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
/// <summary>
/// An Enemy is anything that reacts to the Player's presence
/// </summary>
public class Enemy : MonoBehaviour
{
    public UnityEvent onAlert;
    private Animator anim;
    private NavMeshAgent agent;
    public Animator Anim { get { return anim; } }
    public GameEvent defeatedEvent;

    private bool alerted = false;
    private List<EnemyBehaviour> behaviours;
    private HealthBar bar;
    private Health hp;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        behaviours = new List<EnemyBehaviour>();
        bar = GetComponentInChildren<HealthBar>();
        hp = GetComponent<Health>();
        hp.onHit.AddListener(Hurt);
        hp.onDeath.AddListener(Die);
        foreach (EnemyBehaviour b in GetComponentsInChildren<EnemyBehaviour>())
        {
            behaviours.Add(b);
            b.Init(this);
        }
    }

    /// <summary>
    /// Anim events cannot use BOOLS
    /// </summary>
    public void StartMoving()
    {
        agent.isStopped = false;
    }

    public void StopMoving()
    {
        agent.isStopped = true;
    }

    public void Alert(GameObject p)
    {
        if (alerted) return;

        alerted = true;
        anim.SetBool("alerted", true);
        
        foreach (EnemyBehaviour b in behaviours)
        {
            b.Activate(p);
        }
    }

    public void Hurt()
    {
        bar.UpdateDisplay(hp.Percentage);
    }


    public void Die()
    {
        anim.Play("Dead");
        defeatedEvent.Call(this);
        Destroy(GetComponent<Dangerous>());
        Destroy(gameObject, 0.5f);
    }


}
