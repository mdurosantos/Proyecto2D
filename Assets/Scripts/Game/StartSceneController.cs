using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour
{
    [SerializeField]
    private string level;
    /*private SpriteRenderer loading;

    private void Start()
    {
        loading = GameObject.FindGameObjectWithTag("loading").GetComponent<SpriteRenderer>();
    }*/

    void Update()
    {
        if (Input.GetButton("Interact")) {
            //loading.enabled = true;
            SceneController.LoadScene(level);
        }
    }


}
