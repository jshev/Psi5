using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBot : MonoBehaviour {

    public HealthBarControl healthControl;
    private GameObject Player;
    private Vector2 defaultPosition;
    private int health;

    //public Animator myAnimator;
    public float movementSpeed;
    public float kamikazeRun;
    public bool moving;
    public SpriteRenderer mySpriteRenderer;
    public float pathSize;

    public AudioSource botAudio;
    public AudioSource boomAudio;
    private bool countdown;
    private float tilBoom;
    private bool playedOnce;

    void Start(){
        // localPosition of the position of object when game first starts
        defaultPosition = transform.localPosition;
        movementSpeed = 0.05f;
        kamikazeRun = 0.15f;
        health = 3;

        // moving is always true
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        moving = true;

        Player = GameObject.FindWithTag("Player");
        healthControl = FindObjectOfType<HealthBarControl>();
        botAudio = GetComponent<AudioSource>();
        countdown = false;
        tilBoom = 3f; //decreased the time a bit
        playedOnce = false;
    }

    void FixedUpdate(){
        // flip sprite and change direction if enemy reaches end of its range
        if ((Player.transform.position.y >= (transform.position.y - 0.5)) && (Player.transform.position.y <= (transform.position.y + 0.5)) && (Player.transform.position.x >= (transform.position.x - 7)) && (Player.transform.position.x <= (transform.position.x + 7))) {
            countdown = true;
            if (Player.transform.position.x > transform.position.x) {
                mySpriteRenderer.flipX = false;
                Vector2 newPos = new Vector2(transform.position.x + kamikazeRun, defaultPosition.y);
                transform.position = newPos;
            }
            if (Player.transform.position.x < transform.position.x) {
                mySpriteRenderer.flipX = true;
                Vector2 newPos = new Vector2(transform.position.x - kamikazeRun, defaultPosition.y);
                transform.position = newPos;
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

        if (countdown) {
            if (!playedOnce) {
                botAudio.Play();
                playedOnce = true;
            }
            tilBoom -= Time.deltaTime;
        }

        if (tilBoom < 0) {
            explode();
        }
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "Player") {
            explode();
            //healthControl.instaDeath();
            healthControl.bombHealth();
        }
        if (collide.gameObject.tag == "playerBullet") {
            Destroy(collide.gameObject);
            if (health > 1) {
                health -= 1;
            } else {
                explode();
            }
        }
    }

    public void explode() {
        // used in Combat Block
        gameObject.SetActive(false);
        boomAudio.Play();
    }
}
