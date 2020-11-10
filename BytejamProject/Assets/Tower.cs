using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float angleOffset;
    public float reloadTime;
    float timeSinceLastShot;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Enemy getLastEnemy() {
        Enemy[] enemyList = GameObject.FindObjectsOfType<Enemy>();
        return enemyList[enemyList.Length-1];
    }

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
