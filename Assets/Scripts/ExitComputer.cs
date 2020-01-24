using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitComputer : MonoBehaviour {

    public GameObject computer;
    public AudioSource diskSound;
    public Text Note;
    public GameObject Player;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // when player clicks red x...
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider == gameObject.GetComponent<Collider>()) {
                    // let player move again
                    Player.GetComponent<PlayerMovement>().enabled = true;
                    // make computer, red x, and text disappear
                    gameObject.SetActive(false);
                    computer.SetActive(false);
                    Note.text = " ";
                    // stop playing sound effect
                    if (diskSound.isPlaying) {
                        diskSound.Stop();
                    }
                }
            }
        }
    }
}
