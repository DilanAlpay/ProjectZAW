using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public Player player;
    public Image display;
    // Start is called before the first frame update
    void Start()
    {
        display.sprite = player.choice.character.picture;
    }

}
