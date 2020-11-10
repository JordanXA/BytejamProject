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

            Tower = (GameObject)
              Instantiate(
                GameObject.Find("GameManager").GetComponent<TowerManager>().Tower
              , transform.position, Quaternion.identity);
        }
    }

}
