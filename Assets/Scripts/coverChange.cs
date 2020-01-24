using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coverChange : MonoBehaviour {

    public GameObject player;
    public SpriteRenderer[] covers;
    public GameObject[] holes;
    public float r;
    public float g;
    public float b;
    float a;
    public bool inTunnel = false;
    public bool happened = false;

    void Start()
    {
        a = 1;
        foreach (SpriteRenderer spr in covers)
        {
            spr.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, a);
        }
        foreach (GameObject hol in holes) {
            hol.GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("touched");
            if (!happened) {
                inTunnel = !inTunnel;
                happened = true;
                Debug.Log(inTunnel);
                if (inTunnel) {
                    Debug.Log("trans");
                    foreach (SpriteRenderer spri in covers) {
                        spri.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, 0.5f);
                    } foreach (GameObject hole in holes) {
                        hole.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                if (!inTunnel) {
                    Debug.Log("opaque");
                    foreach (SpriteRenderer sprit in covers) {
                        sprit.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, a);
                    }
                    foreach (GameObject holie in holes) {
                        holie.GetComponent<SpriteRenderer>().enabled = true;
                    }
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
