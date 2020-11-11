using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject TowerPrefab;
    private GameObject Tower;
    private bool CanPlaceTower()
    {
        return Tower == null;
    }

    void OnMouseUp()
    {

        if (CanPlaceTower())
        {
            GameObject towerPrefab = GameObject.Find("GameManager").GetComponent<TowerManager>().Tower;
            int cost = towerPrefab.GetComponent<Placeable>().cost;
            GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();

            if (global.Money > cost)
            {
                Tower = (GameObject)
                  Instantiate(
                    towerPrefab
                  , transform.position, Quaternion.identity);

            }

        }
    }

}
