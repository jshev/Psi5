﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    public Animator animator;      private int levelToLoad;

    void Start()
    {
        animator = GetComponent<Animator>();
    }      public void FadeToNextLevel()
    {         FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);     }      public void FadeToLevel(int levelIndex)
    {         levelToLoad = levelIndex;         animator.SetTrigger("FadeOut");     }      public void OnFadeComplete()
    {         SceneManager.LoadScene(levelToLoad);     }
}
