using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Hauntable : MonoBehaviour
{
    private CameraController camControl;
    private GameObject player;
    private PlayerVisibility playerVisibility;
    private PlayerMovement playerMovement;
    private Collider2D playerCollision;
    private bool playerInRange;
    private bool haunted;

    void Start()
    {
        playerInRange = false;
        haunted = false;
        camControl = Camera.main.GetComponent<CameraController>();
        Init();
    }

    public abstract void Init();
    
    void Update()
    {
        if (!haunted)
        {
            if (playerInRange && Input.GetButtonDown("Interact"))
            {
                haunted = true;
                playerVisibility.setPlayerVisible(false);
                playerMovement.setCanMove(false);
                camControl.Player = transform;
                playerCollision.enabled = false;
                player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0); //TEMP to make player "invisible"
                SwitchDimension();
            }
        }
        else
        {
            if (!Input.GetButton("Interact"))
            {
                haunted = false;
                playerVisibility.setPlayerVisible(true);
                playerMovement.setCanMove(true);
                camControl.Player = player.transform;
                playerCollision.enabled = true;
                player.GetComponent<SpriteRenderer>().color = Color.white; //TEMP to make player visible again
                SwitchDimension();
            }
            else Interact();
        }
    }
    private void SwitchDimension()
    {
        for (int i = 0; i < 2; i++) transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
    }

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if (player == null)
            {
                player = collision.gameObject;
                playerVisibility = player.GetComponent<PlayerVisibility>();
                playerMovement = player.GetComponent<PlayerMovement>();
                playerCollision = player.GetComponent<Collider2D>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerInRange = false;
    }
}
