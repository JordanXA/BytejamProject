using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Jordan Andersen
public class Bullet : MonoBehaviour
{
    public float angle;
    public float speed;
    protected Vector2 velocity;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        float rad = angle * Mathf.Deg2Rad;
        velocity = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(velocity.x, velocity.y, 0);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
