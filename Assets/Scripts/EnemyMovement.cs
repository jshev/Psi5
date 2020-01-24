using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public HealthBarControl healthControl;
    private Vector2 defaultPosition;
    private float elapsedTime;

    public GameObject healthKit;
    private Vector2 dropPos;

    //public Animator myAnimator;
    public float movementSpeed;
    public bool moving;
    public SpriteRenderer mySpriteRenderer;
    public float pathSize;
    

    void Start () {
        // localPosition of the position of object when game first starts
        defaultPosition = transform.localPosition;
        movementSpeed = 0.125f;
        elapsedTime = 0f;

        // moving is always true
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        moving = true;

        healthControl = FindObjectOfType<HealthBarControl>();
     }
	
	void FixedUpdate () {
        // flip sprite and change direction if enemy reaches end of its range
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
            gameObject.SetActive(false);
            if (Random.value < 0.5) {
                dropPos = transform.position;
                dropPos += new Vector2(0f, -1f);
                Instantiate(healthKit, dropPos, Quaternion.identity);
        }
    }
}
}
