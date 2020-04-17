using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private GameObject textTemplate = null;
    [SerializeField] private List<Item> items = new List<Item>();
    private List<Text> textChildren;
    private RectTransform rectTransform;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        textChildren = new List<Text>();
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
        foreach (Text t in textChildren) Destroy(t.gameObject);
        textChildren.Clear();
        foreach (Item i in items) DisplayItem(i);
    }

    public void DisplayItem(Item item)
    {
        GameObject newChild = Instantiate(textTemplate, transform);
        newChild.transform.position += new Vector3(-rectTransform.sizeDelta.x/2 + items.IndexOf(item)*100 + newChild.GetComponent<RectTransform>().sizeDelta.x/2,0);
        Text textChild = newChild.GetComponent<Text>();
        textChildren.Add(textChild);
        textChild.text = item.name;
        newChild.SetActive(true);
    }

    public bool HasItem(Item item)
    {
       return items.Contains(item);
    }


}
