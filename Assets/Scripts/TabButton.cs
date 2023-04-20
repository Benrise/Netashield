using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]

public class TabButton : MonoBehaviour, IPointerEnterHandler,  IPointerClickHandler, IPointerExitHandler
{

    public TabGroup tabGroup;

    public Image backgorund;

    public UnityEvent OnTabSelected;
    public UnityEvent OnTabDeselected;

    public void OnPointerClick(PointerEventData eventData){
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData){
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData){
        tabGroup.OnTabExit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        backgorund = GetComponent<Image>();
        tabGroup.Subscribe(this);
        
    }

    public void Select(){
        if (OnTabSelected != null){
            OnTabSelected.Invoke();
        }
    }

    public void Deselect(){
        if(OnTabSelected != null){
            OnTabSelected.Invoke();
        }
    }
}
