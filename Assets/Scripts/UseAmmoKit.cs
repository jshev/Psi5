using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAmmoKit : MonoBehaviour {

    private AmmoBarControl ammoControl;

    // Use this for initialization
    void Start () {
        ammoControl = FindObjectOfType<AmmoBarControl>();
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "Player") {
            // make object disappear
            gameObject.SetActive(false);
            // see HealthBarControl
            ammoControl.refillAmmo();
        }
    }
}
