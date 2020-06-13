using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private List<Item> items = new List<Item>();
    private GameObject itemTemplate = null;
    private List<GameObject> displayChildren;
    private RectTransform rectTransform;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        itemTemplate = transform.GetChild(0).gameObject;
        rectTransform = GetComponent<RectTransform>();
        displayChildren = new List<GameObject>();
        foreach (Item i in items) DisplayItem(i);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        DisplayItem(item);
    }
    public void AddItems(List<Item> itemsadd)
    {
        foreach (Item i in itemsadd) AddItem(i);
    }

    public void RemoveItems(List<Item> removeItems)
    {
        foreach(Item i in removeItems) items.Remove(i);
        RedrawInventory();
    }

    private void RedrawInventory()
    {
        foreach (GameObject g in displayChildren) Destroy(g);
        displayChildren.Clear();
        foreach (Item i in items) DisplayItem(i);
    }

    public void DisplayItem(Item item)
    {
        GameObject newChild = Instantiate(itemTemplate, transform);
        displayChildren.Add(newChild);
        newChild.GetComponent<RectTransform>().position += new Vector3((items.IndexOf(item)-8)/8f+0.05f,0);
        newChild.GetComponent<Text>().text = item.itemName;
        newChild.GetComponent<SpriteRenderer>().sprite = item.itemImage;
        newChild.SetActive(true);
    }

    public bool HasItem(Item item)
    {
       return items.Contains(item);
    }


}
