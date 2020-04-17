using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] public string itemName = "Unnamed Item";
    [SerializeField] public string itemDescription = "A useless item";
    [SerializeField] public Sprite itemImage = null;
}
