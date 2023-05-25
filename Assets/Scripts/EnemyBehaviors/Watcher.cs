using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : EnemyBehaviour
{
    public float turn;
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, turn * Time.deltaTime);
    }
}
