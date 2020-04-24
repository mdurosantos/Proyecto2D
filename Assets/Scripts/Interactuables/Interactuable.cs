using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactuable : MonoBehaviour
{
    [SerializeField] private bool oneUse = true;
    [SerializeField] private List<Item> requirements = new List<Item>();
    [SerializeField] private List<Item> rewards = new List<Item>();
    //[SerializeField] private int timeCost = 0;
    private bool playerInRange;
    private bool used;

    void Start()
    {
        playerInRange = false;
        used = false;
    }
    
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Interact"))
        {
            if (!oneUse || !used)
            {
                if (HasAllRequiredItems())
                {
                    used = true;
                    Inventory.instance.RemoveItems(requirements);
                    Interact();
                    if (rewards.Count > 0) Inventory.instance.AddItems(rewards);
                }
                //else if (timeCost > 0) PlayerTime.instance.SubstractPoints(timeCost);
            }
            else Debug.Log("This one-use item has already been used.");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = collision.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerInRange = false;
    }
}
