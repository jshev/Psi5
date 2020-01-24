using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarControl : MonoBehaviour {

    public Sprite[] sprites;
    public GameObject Player;
    public Text logsCount;
    public AudioClip roboKiss;
    public AudioClip coll;
    private AudioSource healthAudio;
    private SpriteRenderer render;
    private int healthPos;
    public int health;

    // Use this for initialization
    void Start () {
        healthAudio = GetComponent<AudioSource>();
        render = gameObject.GetComponent<SpriteRenderer>();
        health = 10;
        healthPos = 9;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R)){
            // reload game if player presses R
            SceneManager.LoadScene(PlayerPrefs.GetInt("Lvl"));
        }
    }

    public void decreaseHealth() {
        // used in player-enemy collision
        if (health > 1) {
            // play collision sound effect
            // load lower health bar
            healthAudio.PlayOneShot(coll);
            health -= 1;
            healthPos -= 1;
            render.sprite = sprites[healthPos];
        } else {
            instaDeath();
        }
    }

    public void bombHealth() {
        if (health > 5) {
            // play collision sound effect
            // load lower health bar
            health -= 5;
            healthPos -= 5;
            render.sprite = sprites[healthPos];
        } else {
            instaDeath();
        }
    }

    public void instaDeath() {
        // game over if player collides with enemy at health 1
            // play game over music
            //healthAudio.PlayOneShot(radioStatic);
            // stop player from moving
            //Player.GetComponent<PlayerMovement>().enabled = false;
            // disabling PlayAudio and ReadNotes bc those automatically update
            // log and note count texts
            //Player.GetComponent<PlayAudio>().enabled = false;
            // reset log and note count texts
            //logsCount.text = " ";
            // show game over image
            //GameOver.SetActive(true);
        SceneManager.LoadScene("Game Over");
        }

    public void increaseHealth() {
        // used in player-health kit collision
        healthAudio.PlayOneShot(roboKiss);
        if (health < 7) {
            // if health 7 or less, add two HP and load higher sprite
            health += 3;
            healthPos = health - 1;
            render.sprite = sprites[healthPos];
        } else if (health >= 7) {
            // if health 8,9, or 10, give player full HP and load higher sprite
            health = 10;
            healthPos = 9;
            render.sprite = sprites[healthPos];
        }
    }
}
