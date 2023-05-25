using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// An Enemy is anything that reacts to the Player's presence
/// </summary>
public class Enemy : MonoBehaviour
{
    public UnityEvent onAlert;
    private Animator anim;
    public Animator Anim { get { return anim; } }
    private bool alerted = false;
    private List<EnemyBehaviour> behaviours;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        behaviours = new List<EnemyBehaviour>();
        foreach (EnemyBehaviour b in GetComponentsInChildren<EnemyBehaviour>())
        {
            behaviours.Add(b);
            b.Init(this);
        }
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

    public void Die()
    {
        anim.Play("Dead");
        Destroy(GetComponent<Dangerous>());
        Destroy(gameObject, 0.5f);
    }


}
