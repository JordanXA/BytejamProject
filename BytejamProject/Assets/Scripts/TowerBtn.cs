﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Luc Rurup
public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    public GameObject TowerPrefab;

    public void OnClick() {
        GameObject.Find("GameManager").GetComponent<TowerManager>().PickTower(TowerPrefab);
    }
}
