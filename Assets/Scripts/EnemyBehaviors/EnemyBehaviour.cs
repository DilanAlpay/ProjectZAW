using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Something an enemy can do
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    protected Enemy enemy;
    protected GameObject target;
    public bool startActive = false;
    public bool sightActivated = true;

    public virtual void Init(Enemy e)
    {
        enemy = e;
        enabled = startActive;
    }

    public virtual void Activate(GameObject p)
    {
        enabled = sightActivated;
        target = p;
    }
}
