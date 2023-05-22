using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// An Enemy is anything that reacts to the Player's presence
/// </summary>
public class Enemy : MonoBehaviour
{
    Animator anim;
    private bool alerted = false;
    public UnityEvent onAlert;
    private List<EnemyBehaviour> behaviours;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Alert()
    {
        if (alerted) return;

    }



    public void Die()
    {
        anim.Play("Dead");
        Destroy(GetComponent<Dangerous>());
        Destroy(gameObject, 0.5f);
    }


}
