using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloat : MonoBehaviour {

    private Vector2 defaultPosition;
    private float speed = 0.005f;

	// Use this for initialization
	void Start () {
        // localPosition of the position of object when game first starts
        defaultPosition = transform.localPosition;
    }
	
	void FixedUpdate () {
        // makes items such as audio logs, notes, and keycards float slowly up and down
        if (transform.position.y > (defaultPosition.y + 0.2)) {
            speed = -speed;
        } else if (transform.position.y < (defaultPosition.y - 0.3)) {
            speed = -speed;
        }

        // change item position based on speed
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + speed);
        transform.position = newPos;

    }
}
