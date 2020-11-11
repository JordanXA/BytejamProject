using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject TowerPrefab;
    private GameObject Tower;
    static int munitionsPlaced = 1; //static count through all files of how many munitions towers have been PLACED.
    private bool CanPlaceTower()
    {
        return Tower == null;
    }

    void Start() {
        munitionsPlaced = 1;
        GameObject.Find("MunitionsCost").GetComponent<UnityEngine.UI.Text>().text = "15";
    }

    void OnMouseUp()
    {

        if (CanPlaceTower())
        {
            GameObject towerPrefab = GameObject.Find("GameManager").GetComponent<TowerManager>().Tower;
            int cost = towerPrefab.GetComponent<Placeable>().cost;
            GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();

            if (towerPrefab.GetComponent<Munitions>() != null) {
                cost*=munitionsPlaced;
            }

            if (global.Money >= cost)
            {
                if (towerPrefab.GetComponent<Munitions>() != null) {
                    munitionsPlaced++;
                    GameObject.Find("MunitionsCost").GetComponent<UnityEngine.UI.Text>().text = (15*munitionsPlaced).ToString();
                }

                global.Money -= cost;
                
                Tower = (GameObject)
                  Instantiate(
                    towerPrefab
                  , transform.position, Quaternion.identity);

            }

        }
    }

}
