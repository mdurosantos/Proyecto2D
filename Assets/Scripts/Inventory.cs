using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject textTemplate = null;
    [SerializeField] private List<Item> items = new List<Item>();
    private List<Text> textChildren;
    private RectTransform rectTransform;

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
    public void DisplayItem(Item item)
    {
        GameObject newChild = Instantiate(textTemplate, transform);
        newChild.transform.position += new Vector3(-rectTransform.sizeDelta.x/2 + items.IndexOf(item)*100 + newChild.GetComponent<RectTransform>().sizeDelta.x/2,0);
        Text textChild = newChild.GetComponent<Text>();
        textChildren.Add(textChild);
        textChild.text = item.name;
        newChild.SetActive(true);
    }


}
