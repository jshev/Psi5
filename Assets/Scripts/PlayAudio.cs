using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAudio : MonoBehaviour {

    public AudioClip T1;
    public AudioClip T2;
    public AudioClip T3;
    public AudioClip T4;

    public AudioClip L1L1;
    public AudioClip L1L2;
    public AudioClip L1L3;
    public AudioClip L1L4;
    public AudioClip L1L5;
    public AudioClip L1L6;

    public AudioClip L2L1;
    public AudioClip L2L2;
    public AudioClip L2L4;
    public AudioClip L2L6;

    public AudioClip L3L1;
    public AudioClip L3L2;
    public AudioClip L3L3;
    public AudioClip L3L4;
    public AudioClip L3L5;

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
        rigid2D = GetComponent<Rigidbody2D>();

        // set default PlayerPrefs
        logNo = 0;
        //PlayerPrefs.SetInt("DemoLogs", 0);
        //PlayerPrefs.SetInt("TotalDLs", 1);
        //logsTotal = PlayerPrefs.GetInt("TotalDLs");

        switch (SceneManager.GetActiveScene().name)
        {
            case "Tutorial":
                logsTotal = 4;
                break;
            case "Level1":
                logsTotal = 6;
                break;
            case "Level2":
                logsTotal = 4;
                break;
            case "Level3v2":
                logsTotal = 5;
                break;
            default:
                logsTotal = 999;
                break;
        }

    }

    void Update() {
        // ensures logsCount is always correct, based on PlayerPrefs
        logsCount.text = logNo + "/" + logsTotal;
    }

    void OnCollisionEnter2D(Collision2D collide) {
        // player differentiates audio logs based on tags
        if (collide.gameObject.tag == "T1") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(T1);
        } else if (collide.gameObject.tag == "T2") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(T2);
        } else if (collide.gameObject.tag == "T3") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(T3);
        } else if (collide.gameObject.tag == "T4") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(T4);
        }

        else if (collide.gameObject.tag == "L1L1") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L1L1);
        } else if (collide.gameObject.tag == "L1L2") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L1L2);
        } else if (collide.gameObject.tag == "L1L3") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L1L3);
        } else if (collide.gameObject.tag == "L1L4") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L1L4);
        } else if (collide.gameObject.tag == "L1L5") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L1L5);
        } else if (collide.gameObject.tag == "L1L6") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L1L6);
        }

        else if (collide.gameObject.tag == "L2L1") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L2L1);
        } else if (collide.gameObject.tag == "L2L2") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L2L2);
        } else if (collide.gameObject.tag == "L2L4") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L2L4);
        } else if (collide.gameObject.tag == "L2L6") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L2L6);
            // open info center
            whiteBox.GetComponent<BoxCollider2D>().enabled = false;
            centerInterior.SetActive(true);
            Lock.SetActive(false);
        }

        else if (collide.gameObject.tag == "L3L1") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L3L1);
        } else if (collide.gameObject.tag == "L3L2") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L3L2);
        } else if (collide.gameObject.tag == "L3L3") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L3L3);
        } else if (collide.gameObject.tag == "L3L4") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L3L4);
        } else if (collide.gameObject.tag == "L3L5") {
            // make log disappear
            collide.gameObject.SetActive(false);
            playAudio(L3L5);
        }

    }

    void reactivatePlayer() {
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        Debug.Log("Go!");
    }

    void playAudio(AudioClip clippy) {
        // stop player movement, play audio, update PlayerPrefs, and 
        // let player move again after 45 seconds
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        rigid2D.velocity = new Vector2(0, 0);
        myAudio.clip = clippy;
        myAudio.Play();
        //Invoke("reactivatePlayer", 45);
        Invoke("reactivatePlayer", 5);
        //logNo = PlayerPrefs.GetInt("DemoLogs");
        logNo += 1;
        //PlayerPrefs.SetInt("DemoLogs", logNo);
    }

}
