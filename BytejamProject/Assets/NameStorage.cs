using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameStorage : MonoBehaviour
{

   

    public GameObject inputField;
    public Text changeText;


    public void StoreName()
    {
        
       

        PlayerPrefs.SetString("Player Name", inputField.GetComponent<Text>().text);

        changeText.text = PlayerPrefs.GetString("Player Name");
    }

    private void OnGUI()
    {
        

        PlayerPrefs.SetString("Player Name", inputField.GetComponent<Text>().text);

        changeText.text = PlayerPrefs.GetString("Player Name");
    }
}
