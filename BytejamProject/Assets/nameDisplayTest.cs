using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class nameDisplayTest : MonoBehaviour
{
    public Text changeText;
    private void OnGUI()
    {
        
        changeText.text = PlayerPrefs.GetString("Player Name");
    }
}
