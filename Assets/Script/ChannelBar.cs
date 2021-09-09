using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelBar : MonoBehaviour
{
    public Image bar;
    private void Start()
    {
        bar.fillAmount = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            bar.fillAmount += 0.1f;
            if (bar.fillAmount >= 1f) //bar的數值是float，最少為0f，最高填滿為1f
            {
                bar.fillAmount = 0f;
            }
        }
        
    }
}
