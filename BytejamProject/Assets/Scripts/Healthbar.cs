using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Healthbar : MonoBehaviour
{
    public float maxWidth = 280;
    public float height = 45.5f;
    
    private void OnGUI() {
        GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth*global.health/global.maxHealth,height);
    }

    void Update()
    {
        GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
        if (global.health == 0)
        {
            SceneManager.LoadScene("LossScene");
        }
    }



}
