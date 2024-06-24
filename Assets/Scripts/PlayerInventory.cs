using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Turn inv into dictonary
public class PlayerInventory : MonoBehaviour {
    public ItemManager itemManager;
    public Item[] inventory;

    void Start() {
        inventory = itemManager.items;
    }

    void Update() {
        
    }
}