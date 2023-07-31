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
    public GameEvent defeatedEvent;
    public Knockback knockback;

    public Animator Anim { get { return anim; } }

    private NavMeshAgent agent;
    private Animator anim;
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

    public void Hurt(Damage d)
    {
        bar.UpdateDisplay(hp.Percentage);
        Vector3 dir = (transform.position - d.source.position).normalized;
        StartCoroutine(Knockback(dir));
    }

    IEnumerator Knockback(Vector3 dir)
    {
        Quaternion rotation = transform.rotation;
        //Stored our normal agent values so we don't lose them
        float speed = agent.speed;
        float aSpeed = agent.angularSpeed;
        float acc = agent.acceleration;

        //Set our agent's data for knockback
        agent.speed = knockback.force;
        agent.angularSpeed = 0;
        agent.acceleration = 20;

        float t = 0;
        while (t < knockback.time)
        {
            agent.velocity = dir * knockback.force;

            //Debug.DrawRay(transform.position, goal, Color.cyan);
            t += Time.deltaTime;
            yield return null;
        }
        agent.velocity = Vector3.zero;
        //Return the agent's data back to normal
        agent.speed = speed;
        agent.angularSpeed = aSpeed;
        agent.acceleration = acc;

        transform.rotation = rotation;
    }

    public void Die(Damage damage)
    {
        anim.Play("Dead");
        defeatedEvent?.Call(this);
        Destroy(GetComponent<Dangerous>());
        Destroy(bar.gameObject);
        Destroy(gameObject, 1f);
    }
}
