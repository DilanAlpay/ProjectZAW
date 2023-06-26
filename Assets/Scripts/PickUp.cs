using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PickUp : MonoBehaviour
{
    public Response<Player> onPickUp;

    private void OnTriggerEnter(Collider other)
    {
        onPickUp.Invoke(other.GetComponent<Player>());
        Destroy(gameObject);
    }
}
