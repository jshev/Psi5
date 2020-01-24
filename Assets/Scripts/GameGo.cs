using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGo : MonoBehaviour {

	public void OnGG() {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
