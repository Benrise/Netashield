using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public Sprite defaultSlotImage, selectedSlotImage;

    private void Awake(){
        Deselect();

    }
    public void Select(){
        GetComponent<Image>().sprite = selectedSlotImage;
    }

    public void Deselect(){
         GetComponent<Image>().sprite = defaultSlotImage;
    }

    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0){
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
   
}
