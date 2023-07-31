using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [Range(0,1)]
    public float heartChance = 0.25f;
    public GameObject heart;

    public void TryDrop(Enemy enemy)
    {
        if (Random.Range(0f, 1f) > heartChance) return;
        Instantiate(heart, enemy.transform.position, Quaternion.identity);
    }
}
