using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public bool[] isFull;
    public Button[] slots;

    public Sprite normalSprite; 
    public Sprite selectedSprite;

    private int activeButtonIndex = 0;

    public void Start()
    {
        SetButtonSelected(activeButtonIndex);
    }

    public void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetButtonSelected(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetButtonSelected(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetButtonSelected(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetButtonSelected(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetButtonSelected(4);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }

    }
    private void SetButtonSelected(int newIndex)
    {
        // Сбрасываем предыдущее состояние активной кнопки
        slots[activeButtonIndex].image.sprite = normalSprite;

        // Устанавливаем новую активную кнопку
        activeButtonIndex = newIndex;
        slots[activeButtonIndex].image.sprite = selectedSprite;
    }

    private void Drop()
    {
        // Выбираем текущий активный слот инвентаря
        Transform activeSlot = slots[activeButtonIndex].transform;

        // Проверяем, есть ли в слоту элемент инвентаря
        if (activeSlot.childCount > 0)
        {
            // Получаем компонент DropItem элемента инвентаря в слоту
            DropItem dropItem = activeSlot.GetChild(0).GetComponent<DropItem>();

            // Вызываем метод SpawnDroppedItem() для создания объекта на сцене
            dropItem.SpawnDroppedItem();

            // Удаляем элемент инвентаря из слота
            Destroy(activeSlot.GetChild(0).gameObject);

            // Свобождаем слот инвентаря
            isFull[activeButtonIndex] = false;
        }
    }


}