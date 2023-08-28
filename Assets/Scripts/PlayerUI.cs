using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Player player;
    public Image picture;
    public Image item;

    // Start is called before the first frame update
    void Start()
    {
        picture.sprite = player.choice.character.picture;
    }

    public void UpdateItem(Item i)
    {
        item.sprite = i ? i.icon : null;
    }

    public void UpdatePower(MyPower p)
    {
        item.sprite = p?.power.icon;
    }
}
