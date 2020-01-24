using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : MonoBehaviour {

    private AudioSource myAudio;
    public AudioClip keycardClip;
    public GameObject finishLine;
    public GameObject noEntry;
    public GameObject Entry;
    public bool once;
    public Text logsCount;
    private BoxCollider2D finishColl;
    public LevelChanger lvlChange;

    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
        once = false;
        finishColl = finishLine.GetComponent<BoxCollider2D>();
        lvlChange = FindObjectOfType<LevelChanger>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > Entry.transform.position.x) {
            // show win image
            //winner.gameObject.SetActive(true);
            // stop player from moving
            //GetComponent<PlayerMovement>().enabled = false;
            // disabling PlayAudio and ReadNotes bc those automatically update
            // log and note count texts
            //GetComponent<PlayAudio>().enabled = false;
            // reset log and note count texts
            //logsCount.text = " ";
            //if (!once) {
            // play win music ONCE
            //myAudio.PlayOneShot(helloWorld);
            //once = true;
            //}
            lvlChange.FadeToNextLevel();
        }
    }

    void OnCollisionEnter2D(Collision2D collide) {
        if (collide.gameObject.tag == "key") {
            // make object disappearv and play key sound effect
            collide.gameObject.SetActive(false);
            myAudio.PlayOneShot(keycardClip);
            // disable building collider, allowing player to pass through
            finishColl.enabled = false;
            // entry and no entry images meant to give player feedback
            // what they need in order to move on to next level
            noEntry.gameObject.SetActive(false);
            Entry.gameObject.SetActive(true);
        }

    
    }
}
