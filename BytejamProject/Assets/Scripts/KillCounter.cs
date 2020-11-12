using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Kyler VanDerAa
public class KillCounter : MonoBehaviour
{
    public Text changeText;
    private void OnGUI()
    {
        GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
        changeText.text = global.killCount.ToString();

        PlayerPrefs.SetString("Player Score", changeText.GetComponent<Text>().text);
    }
}
