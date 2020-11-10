using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery_Shell : MonoBehaviour
{
    public float scaleFactor;
    public float explosionRadius;
    public float damage;
    public Vector2 target;
    public float speed;
    Vector2 velocity;

    float distanceToTarget;
    float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 posDiff = target - (Vector2)transform.position;
        posDiff.Normalize(); //fancy math for angle
        float angle = Mathf.Atan2(posDiff.y, posDiff.x);
        velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;

        distanceToTarget = Vector2.Distance(transform.position, target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(velocity.x, velocity.y, 0);
        distanceTravelled += velocity.magnitude;
        
        float distPercent = (distanceTravelled/distanceToTarget);
        //float heightFactor = Mathf.Abs(distPercent*2-1)*1.5f;
        float heightFactor = Mathf.Pow((distPercent*2-1),8)*1.5f;
        transform.localScale = new Vector3(scaleFactor/heightFactor,scaleFactor/heightFactor,1);
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f*heightFactor);

        if (distanceTravelled>distanceToTarget) {
            //explode
            List<Enemy> enemyList = new List<Enemy>(GameObject.FindObjectsOfType<Enemy>());
            enemyList.RemoveAll(enemy => Vector2.Distance(enemy.transform.position,transform.position) > explosionRadius);

            if (enemyList.Count > 0) {
                foreach (Enemy enemy in enemyList) {
                    enemy.health -= damage;
                }
            }
            Destroy(gameObject);
        }
    }

    void Update() {

    }

}
