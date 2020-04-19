using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneCollider : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private PlayerVisibility visibility;
    // Start is called before the first frame update
    void Start()
    {
        visibility = player.GetComponent<PlayerVisibility>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visibility.setPlayerVisible(false);            
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visibility.setPlayerVisible(true);
            Debug.Log("Player left");
        }
    }
}
