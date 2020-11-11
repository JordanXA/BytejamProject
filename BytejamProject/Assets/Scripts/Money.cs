using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;

public class Money : MonoBehaviour{

    public Text TotMoney;
    GlobalVariables global;

    void Start() {
        global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
    }    
    
    
    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(global.Money);
        string totMoney = Convert.ToString(global.Money);
        TotMoney.text = totMoney;
    }
}
