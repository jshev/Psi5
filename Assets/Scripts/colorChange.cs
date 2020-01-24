using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour {

    public float r;
    public float g;
    public float b;

	// Use this for initialization
	void Start () {
        //https://answers.unity.com/questions/730169/changing-the-color-of-all-children-in-an-empty-gam.html
        foreach (SpriteRenderer groundPc in GetComponentsInChildren<SpriteRenderer>()) {
            groundPc.material.color = new Color(r, g, b);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
