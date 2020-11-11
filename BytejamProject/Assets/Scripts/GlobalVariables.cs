using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10;
<<<<<<< HEAD
    public int Money = 30;
    public int maxMoney = 999;
=======
    public int killCount = 0;
    
    void Update()
    {
        
        if (health == 0) 
        {
            SceneManager.LoadScene("LossScene");
        }
    }

>>>>>>> 92f35a2e0afbcbc9fc03fe5dcb70d2fae03224f3
}
