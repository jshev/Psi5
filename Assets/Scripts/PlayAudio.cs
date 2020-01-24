using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour {

    public AudioClip reportLog;
    public AudioClip aliensLog;
    public AudioClip doorLog;
    private int logNo;
    private int logsTotal;
    public Text logsCount;
    private AudioSource myAudio;
    private Rigidbody2D rigid2D;

    public GameObject whiteBox;
    public GameObject Lock;
    public GameObject centerInterior;

    void Start () {
        myAudio = GetComponent<AudioSource>();

        // set default PlayerPrefs
        PlayerPrefs.SetInt("DemoLogs", 0);
        PlayerPrefs.SetInt("TotalDLs", 1);
        logsTotal = PlayerPrefs.GetInt("TotalDLs");

        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // ensures logsCount is always correct, based on PlayerPrefs
        logsCount.text = logNo + "/" + logsTotal;
    }

    void OnCollisionEnter2D(Collision2D collide) {
        // player differentiates audio logs based on tags
        if (collide.gameObject.tag == "reportLog") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(reportLog);
        } else if (collide.gameObject.tag == "aliensLog") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(aliensLog);
        } else if (collide.gameObject.tag == "doorLog") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(doorLog);
            // open info center
            whiteBox.GetComponent<BoxCollider2D>().enabled = false;
            centerInterior.SetActive(true);
            Lock.SetActive(false);
        }
    }

    void reactivatePlayer() {
        gameObject.GetComponent<PlayerMovement>().enabled = true;
    }

    void playAudio(AudioClip clippy) {
        // stop player movement, play audio, update PlayerPrefs, and 
        // let player move again after 45 seconds
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        rigid2D.velocity = new Vector2(0, 0);
        myAudio.clip = clippy;
        myAudio.Play();
        //Invoke("reactivatePlayer", 45);
        Invoke("reactivatePlayer", 22);
        logNo = PlayerPrefs.GetInt("DemoLogs");
        logNo += 1;
        PlayerPrefs.SetInt("DemoLogs", logNo);
    }

}
