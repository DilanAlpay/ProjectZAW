using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public GameObject model;
    public Weapon weapon;
    public Sprite picture;
    public Stats stats;
}
