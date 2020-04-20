﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstantVisionCollider : MonoBehaviour
{
    private EnemyConstantRotation enemy;
    [SerializeField]
    private Transform player;
    private PlayerVisibility visibility;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyConstantRotation>();
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
            enemy.SetPlayerDetected(true);
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && visibility.getPlayerVisible())
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
