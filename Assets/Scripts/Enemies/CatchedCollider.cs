using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchedCollider : MonoBehaviour
{
    [SerializeField] private Transform player = null; //Localización del jugador
    private PlayerVisibility visibility;

    void Start()
    {
        visibility = player.GetComponent<PlayerVisibility>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && visibility.getPlayerVisible())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
