using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTunnel : MonoBehaviour {

    public BoxCollider2D[] tunnels;
    public bool inTunnel = false;
    public bool happened = false;

    void Start() {
        foreach (BoxCollider2D collides in tunnels) {
            collides.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    void Update() {
        if (!inTunnel) {
            Debug.Log("not in tunnel");
        }
    }


    // Update is called once per frame
    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "tunnelCol") {
            if (!happened) {
                inTunnel = !inTunnel;
                happened = true;
                Debug.Log(inTunnel);
                if (inTunnel) {
                    foreach (BoxCollider2D collidies in tunnels) {
                        collidies.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    Debug.Log(happened);
                }
                if (!inTunnel) {
                    foreach (BoxCollider2D colliders in tunnels) {
                        colliders.GetComponent<BoxCollider2D>().enabled = false;
                    }
                    Debug.Log(happened);
                }
            } else {
                inTunnel = !inTunnel;
                happened = false;
            }
        } else {
            Debug.Log("nothing");
        }
    }
}
