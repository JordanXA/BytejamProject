using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionsMoney : MonoBehaviour
{
    float timeSpawned;
    public int moneyFromCollection;
    public float timeToDissapear;
    // Start is called before the first frame update
    void Start()
    {
        timeSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceSpawned = Time.time - timeSpawned;
        float percentDissapeared = (1-timeSinceSpawned/timeToDissapear);

        if(percentDissapeared < 0) {
            Destroy(gameObject);
        }

        //weird weighted average
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,(percentDissapeared*2+1)/3);
    }

    void OnMouseEnter() {
        GameObject.Find("GameManager").GetComponent<GlobalVariables>().Money += moneyFromCollection;
        Destroy(gameObject);
    }
}
