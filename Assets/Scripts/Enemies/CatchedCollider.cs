using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchedCollider : MonoBehaviour
{
    private Transform player;
    private PlayerVisibility visibility;


    void Start()
    {
        player = LevelAccess.GetPlayerPos();
        visibility = player.GetComponent<PlayerVisibility>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && visibility.getPlayerVisible())
        {
            SceneController.LoadCurrentScene();
        }
    }
}
