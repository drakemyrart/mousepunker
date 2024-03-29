﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    TurnManager turnManager;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<PickUPItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            Debug.Log(_item.Id);
            inventory.AddItem(_item, 1);
            Destroy(other.gameObject);
        }
    }

     private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.Load();
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[28];
    }

    
}
