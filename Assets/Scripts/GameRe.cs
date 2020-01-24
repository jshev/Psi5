using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRe : MonoBehaviour{

    public void OnGR(){
        SceneManager.LoadScene(PlayerPrefs.GetInt("Lvl"));
    }
}