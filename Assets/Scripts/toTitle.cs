using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toTitle : MonoBehaviour {

    public void TTitle()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
