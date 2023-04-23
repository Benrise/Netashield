using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSpawnItems : MonoBehaviour
{
    public InventoryManager inventoryManager;
    
    [Header("Element<index> = Spawn Item <index>")]
    public Item[] itemsToPickup;

    public void PickupItem(int id){
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result){
            Debug.Log("Item added");
        }
        else{
            Debug.Log("Item NOT added");
        }
    }

    public void GetSelectedItem(){
        Item receivedItem = inventoryManager.InteractionWithSelectedItem(use: false, drop: true );
        if (receivedItem != null){
            Debug.Log("Received (Dropped)!" + receivedItem);
        }
        else{
            Debug.Log("No item received (No Dropped)!" + receivedItem);
        }
    }
    public void UseSelectedItem(){
        Item usedItem = inventoryManager.InteractionWithSelectedItem(use: true, drop: false );
        if (usedItem != null){
            Debug.Log("Used" + usedItem);
        }
        else{
            Debug.Log("No item used!" + usedItem);
        }
    }
    
}
