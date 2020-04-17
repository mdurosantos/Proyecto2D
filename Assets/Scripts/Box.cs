using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField]
    private bool hasKey;
    [SerializeField]
    private int timeToSubstract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange) //Interact está definido como la barra espaciadora
        {  
            if (hasKey)
            {
                Debug.Log("Give Key");
            }
            else
            {
                Debug.Log("Wasted movement");
            }

            PlayerTime.SubstractPoints(timeToSubstract);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left");
        }
    }
}
