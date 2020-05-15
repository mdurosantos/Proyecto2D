using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            SceneController.LoadNextScene(nextScene);

        }
    }
}
