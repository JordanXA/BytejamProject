using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;

//Author: Luc Rurup
public class Money : MonoBehaviour{

    public Text TotMoney;
    GlobalVariables global;

    void Start() {
        TotMoney = GameObject.Find("TotalMoney").GetComponent<Text>();
        global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
    }    
    
    
    // Update is called once per frame
    void Update()
    {
        string totMoney = Convert.ToString(global.Money);
        TotMoney.text = totMoney;
    }
}
