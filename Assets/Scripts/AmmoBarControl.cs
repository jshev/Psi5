using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBarControl : MonoBehaviour {

    public Sprite[] sprites;
    public GameObject Player;
    public AudioClip pew;
    private AudioSource shootAudio;
    private SpriteRenderer render;

    public int ammo;
    public bool gotAmmo;

    // public GameObject bullet;
    // Vector2 bulletPos;
    // public float firing = 5f;
    // public Transform bulletSpawn;

    // Use this for initialization
    void Start () {
        shootAudio = GetComponent<AudioSource>();
        render = gameObject.GetComponent<SpriteRenderer>();
        ammo = 5;
        gotAmmo = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (ammo >= 1) {
            gotAmmo = true;
        } else {
            gotAmmo = false;
        }
    }

    public void updateAmmoBar() {
        shootAudio.PlayOneShot(pew);
        ammo -= 1;
        render.sprite = sprites[ammo];
    }

    public void refillAmmo() {
        ammo = 5;
        render.sprite = sprites[ammo];
    }
}
