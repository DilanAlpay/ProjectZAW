using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>().Heal(amount))
        {
            Destroy(gameObject);
        }
    }
}
