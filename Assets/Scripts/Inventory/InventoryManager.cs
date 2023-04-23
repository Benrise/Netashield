using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{

    public int maxStackedItems = 10;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    
    

    int selectedSlot = -1;

    private void Start(){
        ChangeSelectedSlot(0);
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
            if (isNumber && number > 0 && number < 6) {
                ChangeSelectedSlot(number-1);
            }
        }
        
    }


    // По возвращению узнаем был ли элемент добавлен в инвентарь
   public bool AddItem (Item item){


        // Поиск первого любого пустого слота
        for (int i = 0; i < inventorySlots.Length; i++){
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && 
            itemInSlot.item == item && 
            itemInSlot.count < maxStackedItems &&
            itemInSlot.item.stackable){
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
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;

   }

   void SpawnNewItem(Item item, InventorySlot slot){
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);

   }


   public Item InteractionWithSelectedItem(bool use, bool drop){

        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null) 
            {
                Item item = itemInSlot.item;
                if (drop){
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0){
                        Destroy(itemInSlot.gameObject);
                    }
                    else{
                        itemInSlot.RefreshCount();
                    }
                }
                else if (use){
                    Destroy(itemInSlot.gameObject);
                }
                else{
                    Debug.Log("Selected item: " + item);
                }
            }

            return null;
   }   

   private const string INVENTORY_KEY = "inventory";

    // Сохраняем инвентарь в PlayerPrefs
    public void SaveInventory()
    {
        List<Item> items = new List<Item>();
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                items.Add(itemInSlot.item);
            }
            else
            {
                items.Add(null);
            }
        }
        string json = JsonUtility.ToJson(items);
        PlayerPrefs.SetString(INVENTORY_KEY, json);
        PlayerPrefs.Save();
    }

    // Загружаем инвентарь из PlayerPrefs
    public void LoadInventory()
    {
        string json = PlayerPrefs.GetString(INVENTORY_KEY);
        List<Item> items = JsonUtility.FromJson<List<Item>>(json);
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            Item item = items[i];
            if (item != null)
            {
                SpawnNewItem(item, slot);
            }
        }
    }

   
}
