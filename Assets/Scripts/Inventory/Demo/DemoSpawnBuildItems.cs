using UnityEngine;

public class DemoSpawnBuildItems : MonoBehaviour
{
    public InventoryManager inventoryManager;
    
    [Header("Element<index> = Spawn Item <index>")]
    public BuildItem[] BuildItemsToPickup;

    public void PickupItem(int id){
        bool result = inventoryManager.AddItem(BuildItemsToPickup[id]);
        if (result){
            Debug.Log("Item added");
        }
        else{
            Debug.Log("Item NOT added");
        }
    }

    public void GetSelectedBuildItem(){
        BuildItem receivedItem = inventoryManager.GetSelectedItem(use: false );
        if (receivedItem != null){
            Debug.Log("Received (Dropped)!" + receivedItem);
        }
        else{
            Debug.Log("No item received (No Dropped)!" + receivedItem);
        }
    }
    public void UseSelectedBuildItem(){
        BuildItem usedItem = inventoryManager.GetSelectedItem(use: true);
        if (usedItem != null){
            Debug.Log("Used" + usedItem);
        }
        else{
            Debug.Log("No item used!" + usedItem);
        }
    }
    
}
