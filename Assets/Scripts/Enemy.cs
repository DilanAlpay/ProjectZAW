using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Die()
    {
        anim.Play("Dead");
        Destroy(GetComponent<Dangerous>());
        Destroy(gameObject, 0.5f);
    }


}
