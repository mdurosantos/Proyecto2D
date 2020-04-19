using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolVisionCollider : MonoBehaviour
{
    private EnemyPatrol patrol;

    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
