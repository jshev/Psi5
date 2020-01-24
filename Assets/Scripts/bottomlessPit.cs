using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottomlessPit : MonoBehaviour {

    public HealthBarControl healthControl;


    // Use this for initialization
    void Start(){
        healthControl = FindObjectOfType<HealthBarControl>();
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "Player") {
            // see HealthBarControl
            healthControl.instaDeath();
        }
    }
}
