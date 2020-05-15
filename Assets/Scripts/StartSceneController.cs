using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private string firstLevel;
    


    void Update()
    {
        if (SpacePressed()) {
            SceneController.LoadNextScene(firstLevel);
        }
    }

    private bool SpacePressed()
    {
        return Input.GetButtonDown("Interact");
    }
}
