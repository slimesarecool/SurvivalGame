using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Data/Item", order = 1)]
public class Item : ScriptableObject {
    public string name = "Item";
    public GameObject model;
    public int maxStack = 100;
    public bool isTool;
    public bool isConsumable;
}