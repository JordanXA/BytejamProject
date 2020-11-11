using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFill : MonoBehaviour
{
    public Text textName;
    public Text textScore;
    private void OnGUI()
    {

        textName.text = PlayerPrefs.GetString("Player Name");
        textScore.text = PlayerPrefs.GetString("Player Score");
    }
}
