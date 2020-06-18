using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gm.lastCheckpointPos = new Vector2(0,0);
            SceneController.LoadNextScene();

        }
    }
}
