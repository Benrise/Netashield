using UnityEngine;
public class InventoryManager : MonoBehaviour
{


    public static InventoryManager instance;
    public BuildItem[] startBuildingItems;
    // public Item[] startItems;

    public int maxStackedItems = 10;
    public InventorySlot[] inventorySlots;

    public GameObject inventoryItemPrefab;
    



    public int slotsForBuild = 3;
    public int slotsForInventory = 6;
    

    public int selectedSlot = -1;


    private void Awake(){
        instance = this;
    }
    private void Start(){
        ChangeSelectedSlot(0);
        if (startBuildingItems != null) {
            foreach (var buildItem in startBuildingItems){
            AddItem(buildItem);
            }
        }

        //     else if (startItems != null) {
        //         foreach (var item in startItems){
        //         AddItem(item);
        //     }
        // }
        foreach (var buildItem in startBuildingItems){
                    AddItem(buildItem);
                }
            

    }

    void ChangeSelectedSlot(int newValue){
        if (selectedSlot >= 0){
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    private void Update(){
        if (Input.inputString != null){
            bool isNumber = int.TryParse(Input.inputString, out int number);
    
            if (startBuildingItems != null){
                    if (isNumber && number > 0 && number < slotsForBuild + 1) {
                        ChangeSelectedSlot(number-1);
            }
            else{
                    if (isNumber && number > 0 && number < slotsForInventory + 1) {
                        ChangeSelectedSlot(number-1);
                    }
                }
            }
        }
        Debug.Log(selectedSlot);
        
    }


//    public bool AddItem (Item item){


//         // Поиск первого любого пустого слота
//         for (int i = 0; i < inventorySlots.Length; i++){
//             InventorySlot slot = inventorySlots[i];
//             InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
//             if (itemInSlot != null && 
//             itemInSlot.item == item && 
//             itemInSlot.count < maxStackedItems &&
//             itemInSlot.item.stackable){
//                 itemInSlot.count++;
//                 itemInSlot.RefreshCount();
//                 return true;
//             }
//         }
//         // Поиск первого любого пустого слота
//         for (int i = 0; i < inventorySlots.Length; i++){
//             InventorySlot slot = inventorySlots[i];
//             InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
//             if (itemInSlot == null){
//                 SpawnNewItem(item, slot);
//                 return true;
//             }
//         }
//         return false;

//    }

   public bool AddItem (BuildItem buildItem){


        // Поиск первого любого пустого слота
        for (int i = 0; i < inventorySlots.Length; i++){
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && 
            itemInSlot.buildItem == buildItem && 
            itemInSlot.count < maxStackedItems &&
            itemInSlot.buildItem.stackable){
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Поиск первого любого пустого слота
        for (int i = 0; i < inventorySlots.Length; i++){
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null){
                SpawnNewItem(buildItem, slot);
                return true;
            }
        }
        return false;

   }

//    void SpawnNewItem(Item item, InventorySlot slot){
//         GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
//         InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
//         inventoryItem.InitialiseItem(item);
//    }

   void SpawnNewItem(BuildItem buildItem, InventorySlot slot){
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(buildItem);


   }


//    public Item InteractionWithSelectedItem(bool use, bool drop){

//         InventorySlot slot = inventorySlots[selectedSlot];
//         InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
//             if (itemInSlot != null) 
//             {
//                 Item item = itemInSlot.item;
//                 if (drop){
//                     itemInSlot.count--;
//                     if (itemInSlot.count <= 0){
//                         Destroy(itemInSlot.gameObject);
//                     }
//                     else{
//                         itemInSlot.RefreshCount();
//                     }
//                 }
//                 else if (use){
//                     Destroy(itemInSlot.gameObject);
//                 }
//                 else{
//                     Debug.Log("Selected item: " + item);
//                 }
//             }

//             return null;
//    }
    
    public BuildItem GetSelectedItem(bool use){
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null) 
            {
                BuildItem buildItem = itemInSlot.buildItem;
                if (use){
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCount();
                    }
                }
                return buildItem;
            }

            return null;
   }   
   
}
