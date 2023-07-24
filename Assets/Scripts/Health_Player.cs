using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Player : Health
{
    public Transform display;

    public override void Hurt(Damage damage)
    {
        base.Hurt(damage);
        UpdateDisplay();
    }

    public override bool Heal(int amount)
    {
        bool healed = base.Heal(amount);
        UpdateDisplay();
        return healed;
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < display.childCount; i++)
        {
            display.GetChild(i).gameObject.SetActive(i<hp);
        }
    }

}
