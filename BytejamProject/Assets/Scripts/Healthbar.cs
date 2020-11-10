using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public float maxWidth = 280;
    public float height = 45.5f;
    
    private void OnGUI() {
        GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth*global.health/global.maxHealth,height);
    }
}
