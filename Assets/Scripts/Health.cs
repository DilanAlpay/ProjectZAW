using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    protected int hp;
    public int maxHp = 1;
    public float iFrames = 0;
    private float iTimer;
    public UnityEvent onHit;
    public UnityEvent onDeath;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }


    public virtual void Hurt(Damage damage)
    {
        if (Time.time < iTimer || hp <= 0) return;

        hp -= damage.amount;

        if (hp <= 0)
        {
            Die();
        }
        else
        {
            onHit.Invoke();
            iTimer = Time.time + iFrames;
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
