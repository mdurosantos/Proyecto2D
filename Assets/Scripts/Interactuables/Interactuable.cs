using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactuable : MonoBehaviour
{
    [SerializeField] private bool oneUse = true;
    [SerializeField] private List<Item> requirements = new List<Item>();
    [SerializeField] protected List<Item> rewards = new List<Item>();
    private bool playerInRange;
    private bool used;
    private Text feedback;
    private GameFlowController gameFlowController;

    void Start()
    {
        playerInRange = false;
        used = false;
        Init();
        feedback = GameObject.FindGameObjectWithTag("Feedback").GetComponent<Text>();
        gameFlowController = GameObject.FindGameObjectWithTag("GameFlowController").GetComponent<GameFlowController>();
    }
    
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Interact") && !gameFlowController.GetGameOver())
        {
            if (!oneUse || !used)
            {
                if (HasAllRequiredItems())
                {
                    used = true;
                    feedback.text = "";
                    Inventory.instance.RemoveItems(requirements);
                    Interact();
                    if (rewards.Count > 0) Inventory.instance.AddItems(rewards);
                }
                else
                {
                    feedback.text = "You need a key";
                }
            }
            else Debug.Log("This one-use item has already been used.");
        }
        else if (gameFlowController.GetGameOver())
        {
            feedback.text = "";
        }
    }
    
    private bool HasAllRequiredItems()
    {
        if (requirements.Count > 0)
        {
            foreach (Item i in requirements) if (!Inventory.instance.HasItem(i))
                {
                    Debug.Log("This action requires at least one "+i.itemName);
                    return false;
                }
        }
        return true;
    }

    public abstract void Interact();
    public abstract void Init();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = collision.CompareTag("Player");
        if (playerInRange && !used) feedback.text = "Press Space to Interact";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerInRange = false;
        if (!playerInRange) feedback.text = "";
    }
}
