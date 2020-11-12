﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Jordan Andersen
public class Tower : Placeable
{

    public float detectionRange;
    public float angleOffset;
    public float reloadTime;
    protected float timeSinceLastShot;
    public GameObject bulletPrefab;

    protected Enemy getLastEnemy() {
        List<Enemy> enemyList = new List<Enemy>(GameObject.FindObjectsOfType<Enemy>());

        //sorts list so last element is the furthest enemy.
        enemyList.Sort(SortByDistanceTravelled);

        if (enemyList.Count > 0) {
            return enemyList[enemyList.Count-1];
        }
        else {
            return null;
        }
    }

    protected Enemy getLastEnemy(float range) {
        List<Enemy> enemyList = new List<Enemy>(GameObject.FindObjectsOfType<Enemy>());

        enemyList.RemoveAll(enemy => Vector2.Distance(enemy.transform.position,transform.position) > range);

        //sorts list so last element is the furthest enemy.
        enemyList.Sort(SortByDistanceTravelled);

        if (enemyList.Count > 0) {
            return enemyList[enemyList.Count-1];
        }
        else {
            return null;
        }
    }

    protected static int SortByDistanceTravelled(Enemy e1, Enemy e2) {
        return e1.distTravelled.CompareTo(e2.distTravelled);
    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemy = getLastEnemy(detectionRange);
        bool towerShot = false;

        if (enemy != null) { //enemy exists
            Vector2 enemyPos = enemy.transform.position;
            Vector2 posDiff = enemyPos -  (Vector2)transform.position;
            posDiff.Normalize(); //fancy math for angle
            float angle = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg;
            Quaternion currentRotation = transform.rotation;
            currentRotation.eulerAngles = new Vector3(0,0,angle+angleOffset);
            transform.rotation = currentRotation;

            if (timeSinceLastShot > reloadTime) {
                Shoot(enemy, angle);
                towerShot = true;
                timeSinceLastShot = 0;
            }
        }

        if (!towerShot) {
            timeSinceLastShot += Time.deltaTime;
        }

    }

    void Shoot(Enemy enemy, float angle) {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, new Quaternion());
        bullet.GetComponent<Bullet>().angle = angle;
    }
}
