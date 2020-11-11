using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : Tower
{

    private new Enemy getLastEnemy(float range) {
        List<Enemy> enemyList = new List<Enemy>(GameObject.FindObjectsOfType<Enemy>());

        //makes sure enemies are further than the range value
        enemyList.RemoveAll(enemy => Vector2.Distance(enemy.transform.position,transform.position) < range);

        //sorts list so last element is the furthest enemy.
        enemyList.Sort(SortByDistanceTravelled);

        if (enemyList.Count > 0) {
            return enemyList[enemyList.Count-1];
        }
        else {
            return null;
        }
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
                Shoot(enemy);
                towerShot = true;
                timeSinceLastShot = 0;
            }
        }

        if (!towerShot) {
            timeSinceLastShot += Time.deltaTime;
        }

    }

    void Shoot(Enemy enemy) {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, new Quaternion());
        bullet.GetComponent<Artillery_Shell>().target = enemy.transform.position;
    }
}
