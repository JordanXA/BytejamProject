using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Author: Jordan Andersen
public class Munitions : Placeable
{
    public GameObject moneyPrefab;
    public float timeToSpawnMoney;
    float lastTimeSpawned;

    System.Random rand = new System.Random();

    void Start() {
        lastTimeSpawned = Time.time;
    }
    void Update() {
        float timeSinceSpawned = Time.time - lastTimeSpawned;
        if (timeSinceSpawned > timeToSpawnMoney) {
            lastTimeSpawned = Time.time;
            Vector3 randomPos = new Vector3((float)rand.NextDouble(), (float)rand.NextDouble(), 0);
            Instantiate(moneyPrefab, transform.position+randomPos, transform.rotation);
        }
    }
}
