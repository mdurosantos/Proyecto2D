using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    private Animator animator;
    private string levelToLoad;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }


    public void FadeToLevel (string level)
    {
        levelToLoad = level;
        animator.SetTrigger("fadeOut");
    }

    public void OnFadeComplete()
    {
        if (levelToLoad.Equals("next"))
            SceneController.LoadNextScene();
        else
            SceneController.LoadScene(levelToLoad);
    }
}
