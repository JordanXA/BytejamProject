using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2Name : MonoBehaviour
{
   

    // Update is called once per frame
    public void MenuToName()
    {
        SceneManager.LoadScene("NameScene");
    }

    public void NameToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameToLame()
    {
        SceneManager.LoadScene("LossScene");
    }

    public void LameToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
