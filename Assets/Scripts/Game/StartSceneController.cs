using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private string firstLevel;
    /*private SpriteRenderer loading;

    private void Start()
    {
        loading = GameObject.FindGameObjectWithTag("loading").GetComponent<SpriteRenderer>();
    }*/

    void Update()
    {
        if (Input.GetButton("Interact")) {
            //loading.enabled = true;
            SceneController.LoadNextScene();
        }
    }


}
