using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Author: All of us
public class GlobalVariables : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10;
    public int Money = 30;
    public int maxMoney = 999;
    public int killCount = 0;
    
    void Update()
    {
        
        if (health == 0) 
        {
            SceneManager.LoadScene("LossScene");
        }
    }

}
