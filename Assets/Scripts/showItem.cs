using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showItem : MonoBehaviour {

    public void OnShowI()
    {
        SceneManager.LoadScene("Items", LoadSceneMode.Single);
    }
}
