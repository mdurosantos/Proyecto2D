using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomVisionCollider : MonoBehaviour
{
    private EnemyRandomRotation enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyRandomRotation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.SetPlayerDetected(true);
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
