using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class OdliczanieCzasu : MonoBehaviour
{
    [SerializeField]
    public Text text;
    private float sekunda = 0.0f;
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    float minuts = 0;
    float hour;
    string sekundy1;
    string minuty;
    string godzina = "00";
    // Start is called before the first frame update
    void Update()
    {
        sekunda += Time.deltaTime;
        if(sekunda >= 1)
        {
            minuts += 1;
            sekunda = 0;
        }
        if (minuts < 10)
        {
            minuty = "0" + minuts.ToString();
        }
        else if (minuts < 60)
        {
            minuty = minuts.ToString();
        }
        else
        {
            hour += 1;
            if (minuts < 10)
            {
                godzina = "0" + hour.ToString();
            }
            else
            {
                godzina = hour.ToString();
            }
            sekunda = 0;
        }
        if (sekunda < 0.10)
        {
            if (String.Format("{0:N0}", sekunda * 100) != "00" && String.Format("{0:N0}", sekunda * 100) != "10") { 
                sekundy1 = "0" + String.Format("{0:N0}", sekunda * 100);
             }
        }
        else
        {
            if (String.Format("{0:N0}", sekunda * 100) != "100")
            {
                sekundy1 = String.Format("{0:N0}", sekunda * 100);
            }
        }
        text.text = godzina + ":"+minuty + ":" + sekundy1.ToString();
    }
}
