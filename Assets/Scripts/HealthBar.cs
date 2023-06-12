using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    Image display;
    Color[] colors = new Color[] { Color.green, Color.yellow, Color.red };

    // Start is called before the first frame update
    void Awake()
    {
        display = transform.GetChild(1).GetComponent<Image>();
    }


    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
    public void UpdateDisplay(float p)
    {
        display.fillAmount = p;
    }
}
