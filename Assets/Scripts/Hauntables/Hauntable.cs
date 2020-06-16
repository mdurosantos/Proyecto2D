using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] [Range(0.2f, 2f)] private float offsetScale = 1f;
    [SerializeField] [Range(0.1f, 3f)] private float hauntTime = 0.5f;
    private Slider slider;
    private float hauntAmount;

    void Start()
    {
        playerInRange = false;
        haunted = false;
        camControl = Camera.main.GetComponent<CameraController>();
        hauntAmount = 0f;
        Init();
    }

    public abstract void Init();
    
    void Update()
    {
        if (!haunted)
        {
            if (playerInRange && Input.GetButton("Interact"))
            {
                if (hauntAmount >= hauntTime)
                {
                    AudioManager.PlaySound("haunt");
                    slider.gameObject.SetActive(false);
                    haunted = true;
                    playerMovement.setCanMove(false);
                    playerVisibility.setPlayerVisible(false);
                    playerMovement.setCanMove(false);
                    camControl.ChangeTarget(transform, offsetScale);
                    playerCollision.enabled = false;
                    player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0); //TEMP to make player "invisible"
                    SwitchDimension();
                }
                else
                {
                    slider.gameObject.SetActive(true);
                    hauntAmount += Time.deltaTime;
                    slider.value = hauntAmount / hauntTime;
                }
            }
            else if(hauntAmount > 0f)
            {
                hauntAmount = 0f;
                slider.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!Input.GetButton("Interact"))
            {
                AudioManager.PlaySound("dehaunt");
                hauntAmount = 0f;
                haunted = false;
                playerVisibility.setPlayerVisible(true);
                playerMovement.setCanMove(true);
                camControl.ChangeTarget(player.transform, 1f);
                playerCollision.enabled = true;
                player.GetComponent<SpriteRenderer>().color = Color.white; //TEMP to make player visible again
                SwitchDimension();
            }
            else {
                Interact(); }
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
                slider = player.transform.Find("Canvas/Slider").gameObject.GetComponent<Slider>();
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
