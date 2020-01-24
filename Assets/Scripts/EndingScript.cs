using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {
    private GameObject Player;
    private AudioSource SPEECH;
    private AudioSource elderAudio;
    private bool once;
    private bool choiceMade;
    public AudioClip panic;
    public AudioClip blastOff;
    public GameObject blackOut;

    // Use this for initialization
    void Start() {
        Player = GameObject.FindWithTag("Player");
        SPEECH = GameObject.Find("SPEECH").GetComponent<AudioSource>();
        elderAudio = GetComponent<AudioSource>();
        once = false;
        choiceMade = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Player.transform.position.x >= -13 && !once) {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //SPEECH.Play();
            Invoke("reactivatePlayer", 5);
        }
        if (choiceMade) {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "Player") {
            endGame(blastOff);
        }

        if (collide.gameObject.tag == "playerBullet") {
            endGame(panic);
        }
    }

    public void endGame(AudioClip clip) {
        choiceMade = true;
        blackOut.SetActive(true);
        elderAudio.clip = clip;
        elderAudio.Play();
        Invoke("loadCredits", 15);
    }

    void loadCredits() {
        SceneManager.LoadScene("Credits");
    }

    void reactivatePlayer(){
        Player.GetComponent<PlayerMovement>().enabled = true;
        once = true;
    }
}
