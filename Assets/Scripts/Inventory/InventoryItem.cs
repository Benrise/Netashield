using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public TMP_Text countText;
    public TMP_Text usesNumText;

    [HideInInspector]public Transform parentAfterDrag;

    [HideInInspector]public Item item;
    [HideInInspector]public int count = 1;
    [HideInInspector]public int usesNum = 5;


    private void Start(){
        InitialiseItem(item);
        RefreshInfo();
    }

    public void InitialiseItem(Item newItem) {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshInfo(){
        if (item.stackable){
            countText.transform.parent.gameObject.SetActive(true);
            usesNumText.transform.parent.gameObject.SetActive(false);
        } else {
            countText.transform.parent.gameObject.SetActive(false);
            usesNumText.transform.parent.gameObject.SetActive(true);
        }
        if (item.type == ItemType.Tool && item.stackable) {
            countText.transform.parent.gameObject.SetActive(true);
            usesNumText.transform.parent.gameObject.SetActive(false);
        }
        else if (item.type == ItemType.CraftingItem){
            countText.transform.parent.gameObject.SetActive(false);
            usesNumText.transform.parent.gameObject.SetActive(false);
        }
    }



    public void RefreshCount(){
        countText.text = count.ToString();
        Debug.Log(count);
        bool isTextActive = count > 1;
        Transform parentTransform = countText.transform.parent;
        parentTransform.gameObject.SetActive(isTextActive);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

}