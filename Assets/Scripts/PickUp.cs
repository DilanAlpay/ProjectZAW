using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PickUp : MonoBehaviour
{
    public Response<Player> onPickUp;

    private void OnTriggerEnter(Collider other)
    {
        Collect(other.GetComponent<Player>());
        Destroy(gameObject);
    }

    public virtual void Collect(Player player)
    {
        onPickUp.Invoke(player);
    }
}
