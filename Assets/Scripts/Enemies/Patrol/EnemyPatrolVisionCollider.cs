using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolVisionCollider : MonoBehaviour
{
    private EnemyPatrol patrol;
    private Transform player;
    private PlayerVisibility visibility;

    // Start is called before the first frame update
    void Start()
    {
        player = LevelAccess.GetPlayerPos();
        patrol = GetComponent<EnemyPatrol>();
        visibility = player.GetComponent<PlayerVisibility>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && visibility.getPlayerVisible())
        {
            CheckForPlayer();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && visibility.getPlayerVisible())
        {
            CheckForPlayer();
        }
    }


    private void CheckForPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        RaycastHit2D[] hits = new RaycastHit2D[3];
        Physics2D.Raycast(transform.position, direction, new ContactFilter2D(), hits);
        //Debug.DrawRay(transform.position, direction, Color.red);
        if (hits[0].collider.gameObject.transform.Equals(player.transform))
        {
            patrol.SetPlayerDetected(true);
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player left");
        }
    }
}
