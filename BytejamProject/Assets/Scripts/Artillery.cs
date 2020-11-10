using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : Tower
{
    // Update is called once per frame
    void Update()
    {
        Enemy enemy = getLastEnemy();
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
