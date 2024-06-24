using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public Item[] items;

    void Start() {
        foreach (Item item in items) {
            registerItem(item);
        }
    }

    void Update() {
        
    }

    void registerItem(Item item) {
        Debug.Log(item.name);
    }
}