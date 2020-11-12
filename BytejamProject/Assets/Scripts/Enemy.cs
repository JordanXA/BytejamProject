using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Author: Jordan Andersen
public class Enemy : MonoBehaviour
{
    enum Direction {
        Right, Left, Up, Down
    }

    public Sprite leftRightSprite;
    public Sprite upDownSprite;
    
    public float distTravelled; //tracks how far the enemy has travelled

    public float health;
    float max_health;

    static readonly float DISTANCE_TO_POINT_BEFORE_CHANGING_DIRECTIONS = .01f;
    public float speed;
    Transform[] waypoints;
    int targetPoint;
    public GameObject moneyPrefab;

    System.Random rand = new System.Random();

    Vector3 targetPos() {
        return waypoints[targetPoint].position;
    }
    // Start is called before the first frame update
    void Start()
    {
        max_health = health;
        waypoints = Waypoints.points;
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update() {

        Vector3 movement = moveToTarget();

        distTravelled += Vector3.Magnitude(movement*speed*Time.deltaTime);
        transform.position = transform.position + movement*speed*Time.deltaTime;

        if ( movement.x == 0 && movement.y == 0 ) {
            targetPoint++; //advance to next point if moveToTarget() decided we dont need to move to this one anymore
        }

        UpdateSprite(movement);
        float hColor = health/max_health;
        GetComponent<SpriteRenderer>().color = new Color(1f,1f*hColor,1f*hColor,1f);
        
        if (targetPoint > waypoints.Length-1) { //object reached end of scene. destroy and remove health.
            GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
            global.health -= 1;
            Destroy(gameObject);
        }

        if (health <= 0) {
            GlobalVariables global = GameObject.Find("GameManager").GetComponent<GlobalVariables>();
            global.killCount++;
            if(rand.NextDouble() > .8f) {
                Vector3 randomPos = new Vector3((float)rand.NextDouble(), (float)rand.NextDouble(), 0);
                Instantiate(moneyPrefab, transform.position+randomPos, transform.rotation);
            }
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet != null) {
            health -= bullet.damage;
            Destroy(bullet.gameObject);
        }
    }

    void UpdateSprite(Vector3 movement) {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Animator animator = GetComponent<Animator>();
        
        if(leftRightSprite != null) {
            if (movement.x > 0) { //moving right
                animator.enabled = true;
                spriteRenderer.sprite = leftRightSprite;
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
            } else if (movement.x < 0) { //moving left
                animator.enabled = true;
                spriteRenderer.sprite = leftRightSprite;
                spriteRenderer.flipX = true;
                spriteRenderer.flipY = false;
            }
        }

        if(upDownSprite != null) {
            if (movement.y > 0) { //moving up
                animator.enabled = false;
                spriteRenderer.sprite = upDownSprite;
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = true;
            } else if (movement.y < 0) { //moving down
                animator.enabled = false;
                spriteRenderer.sprite = upDownSprite;
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
            }
        }

    }

    Vector3 moveToTarget() {
        Vector3 movement = new Vector3();

        float xDiff = transform.position.x - targetPos().x;
        float yDiff = transform.position.y - targetPos().y;
        
        if (Math.Abs(xDiff) < DISTANCE_TO_POINT_BEFORE_CHANGING_DIRECTIONS) { //don't bother moving, close enough to the waypoint
            movement.x = 0; 
        }
        else if (xDiff < 0) { // target to the right
            movement.x = 1;
        }
        else { //target to the left
            movement.x = -1;
        }

        //dont move in the y axis until done moving in the x axis
        if (movement.x == 0) {
            if (Math.Abs(yDiff) < DISTANCE_TO_POINT_BEFORE_CHANGING_DIRECTIONS) { //don't bother moving, close enough to the waypoint
                movement.y = 0; 
            }
            else if (yDiff < 0) { // target to the right
                movement.y = 1;
            }
            else { //target to the left
                movement.y = -1;            
            }
        }

        movement.z = 0; //no 3d

        return movement;

    }
}
