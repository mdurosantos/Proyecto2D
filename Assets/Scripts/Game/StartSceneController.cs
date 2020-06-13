using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private string firstLevel;
    


    void Update()
    {
        if (Input.GetButton("Interact")) {
            SceneController.LoadNextScene();
        }
    }

    private bool SpacePressed()
    {
        return Input.GetButton("Interact");
    }
}
