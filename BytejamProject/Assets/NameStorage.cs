using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameStorage : MonoBehaviour
{
   
    public GameObject inputField;
    

    public void StoreName()
    {
        
        GlobalVariables.playerName = inputField.GetComponent<Text>().text;
    }
}
