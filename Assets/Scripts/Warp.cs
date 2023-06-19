using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Vector3 destination;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = destination;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(destination, 3f);
    }
}
