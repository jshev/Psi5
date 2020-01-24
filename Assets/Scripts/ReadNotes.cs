using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour {

    public GameObject computer;
    public GameObject redX;
    public AudioSource diskSound;
    public Text Note;
    public Text notesCount;
    private int noteNo;
    private int noteTotal;
    private Rigidbody2D rigid2D;

    void Start() {
        // set default PlayerPrefs
        PlayerPrefs.SetInt("DemoNotes", 0);
        PlayerPrefs.SetInt("TotalDNs", 0);
        noteTotal = PlayerPrefs.GetInt("TotalDNs");
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // ensures logsCount is always correct, based on PlayerPrefs
        notesCount.text = noteNo + "/" + noteTotal;
    }

    void OnCollisionEnter2D(Collision2D collide) {
        // player differentiates notes based on tags
        if (collide.gameObject.tag == "introNote") {
            // set note text to script
            // make note disappear
            Note.text = "Mission Debrief\n" +
                "Droid 314159 (Codename Psi 5)\n \n" +
                "The colony of Eden 5 has been out of contact for several Earth months. " +
                "Captain Drew Jackson’s status report and the colony’s supplies shipment " +
                "are either late or missing.\n \n" + "Your job is to scout out Eden 5 and assess " +
                "the situation. Be thorough in your investigation, as an inadequate report " +
                "will result in a cognitive reprogramming session.\n \n" + "Command will be awaiting " +
                "your mission report. Good luck and godspeed, droid.";
            collide.gameObject.SetActive(false);
            iLoveComputer();
        } else if (collide.gameObject.tag == "demoNote") {
            // set note text to script
            // make note disappear
            Note.text = "Note to Staff:\n \nThe surveillance hovercraft has an extra keycard to " +
                "the exit in the event that one of the guards or ship technicians loses or " +
                "forgets theirs and gets trapped in the docking station.\n \nRemember that anyone " +
                "that wanders into the docking station without proper clearance must be brought " +
                "to Captain Jackson to face immediate disciplinary action.\n \nWe have rules for a " +
                "reason. Without them, Eden would fall into perdition.";
            collide.gameObject.SetActive(false);
            iLoveComputer();
        }
    }

    void ActivateRedX() {
        redX.SetActive(true);
    }

    void iLoveComputer() {
        // stop player movement, show computer and text, play floppy disk sound,
        // update PlayerPrefs, and show red x after 5 seconds
        GetComponent<PlayerMovement>().enabled = false;
        rigid2D.velocity = new Vector2(0, 0);
        computer.SetActive(true);
        diskSound.loop = true;
        diskSound.Play();
        Invoke("ActivateRedX", 5);
        noteNo = PlayerPrefs.GetInt("DemoNotes");
        noteNo += 1;
        PlayerPrefs.SetInt("DemoNotes", noteNo);
    }
}
