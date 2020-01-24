using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCombat : MonoBehaviour {

    public HealthBarControl healthControl;
    private GameObject Player;
    private Vector2 defaultPosition;
    private int health;
    private float elapsedTime;

    //public Animator myAnimator;
    public float movementSpeed;
    public bool moving;
    public SpriteRenderer mySpriteRenderer;
    public float pathSize;

    public GameObject bulletRight, bulletLeft;
    private Vector2 bulletPos;
    public GameObject ammoKit;
    private Vector2 dropPos;
    public float fireRate = 100f;
    private float fireNext = 0f;

    void Start() {
        // localPosition of the position of object when game first starts
        defaultPosition = transform.localPosition;
        movementSpeed = 0.05f;
        health = 2;
        elapsedTime = 0f;

        // moving is always true
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        moving = true;

        Player = GameObject.FindWithTag("Player");
        healthControl = FindObjectOfType<HealthBarControl>();
    }

    void FixedUpdate() {
        // flip sprite and change direction if enemy reaches end of its range
        if ((Player.transform.position.y >= (transform.position.y - 0.5)) && (Player.transform.position.y <= (transform.position.y + 0.5)) && (Player.transform.position.x >= (transform.position.x - 10)) && (Player.transform.position.x <= (transform.position.x + 10))) {
                if (Player.transform.position.x > transform.position.x) {
                    mySpriteRenderer.flipX = false;
                    if (Time.time > fireNext) {
                        fireNext = Time.time + fireRate;
                        fire();
                    }
                } if (Player.transform.position.x < transform.position.x) {
                mySpriteRenderer.flipX = true;
                bulletPos = transform.position;
                if (Time.time > fireNext) {
                    fireNext = Time.time + fireRate;
                    fire();
                }
            }
        } else {
            if ((transform.position.x > (defaultPosition.x + pathSize))) {
                mySpriteRenderer.flipX = true;
                movementSpeed = -movementSpeed;
            }
            if ((transform.position.x < (defaultPosition.x - pathSize))) {
                mySpriteRenderer.flipX = false;
                movementSpeed = -movementSpeed;
            }

            // change position of enemy based on movement speed
            Vector2 newPos = new Vector2(transform.position.x + movementSpeed, defaultPosition.y);
            transform.position = newPos;
        }

        if (mySpriteRenderer.flipX) {
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.7f, 0f);
        } else {
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.7f, 0f);
        }

        if (elapsedTime > 0) {
            elapsedTime -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "Player") {
            if (elapsedTime <= 0) {
                elapsedTime = 2f;
                // see HealthBarControl
                healthControl.decreaseHealth();
            }
        }
        if (collide.gameObject.tag == "playerBullet") {
            Destroy(collide.gameObject);
            if (health > 1) {
                health -= 1;
            }
            else {
                gameObject.SetActive(false);
                if (Random.value < 0.5) {
                    dropPos = transform.position;
                    dropPos += new Vector2(0f, -1f);
                    Instantiate(ammoKit, dropPos, Quaternion.identity);
                }
            }
        }
    }

    public void fire() {
        // used in Combat Block
        bulletPos = transform.position;
        if (mySpriteRenderer.flipX) {
            //left
            bulletPos += new Vector2(-2f, -0.25f);
            Instantiate(bulletLeft, bulletPos, Quaternion.identity);
        } else {
            //right
            bulletPos += new Vector2(+2f, -0.25f);
            Instantiate(bulletRight, bulletPos, Quaternion.identity);
        }
    }
}
