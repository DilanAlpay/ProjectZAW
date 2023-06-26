using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Player player;
    public Image picture;
    public Image power;

    // Start is called before the first frame update
    void Start()
    {
        picture.sprite = player.choice.character.picture;
    }

    public void UpdatePower(MyPower p)
    {
        power.sprite = p?.power.icon;
    }
}
