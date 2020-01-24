using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHealthKit : MonoBehaviour {

    private HealthBarControl healthControl;

    void Start () {
        healthControl = FindObjectOfType<HealthBarControl>();
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "Player") {
            // make object disappear
            gameObject.SetActive(false);
            // see HealthBarControl
            healthControl.increaseHealth();
        }
    }
}
