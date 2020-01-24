using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toInstruct : MonoBehaviour {

	public void OnTI()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }
}
