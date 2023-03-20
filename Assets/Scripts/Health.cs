using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    private int hp;
    public int maxHp = 1;
    public float iFrames = 0;
    public UnityEvent onHit;
    public UnityEvent onDeath;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    public void Hurt(Damage damage)
    {
        hp -= damage.amount;

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if(onDeath.GetPersistentEventCount() == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            onDeath.Invoke();
        }
    }
}
