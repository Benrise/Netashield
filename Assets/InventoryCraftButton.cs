using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCraftButton : MonoBehaviour
{

    public GameObject craftInfoWindow;
    public GameObject inventoryWindow;
    public Button switchButton;

    private bool IsCraftInfoWindowActive = true;

    public TMP_Text whatShow;

    void Awake()
    {
        craftInfoWindow.SetActive(IsCraftInfoWindowActive);
        inventoryWindow.SetActive(!IsCraftInfoWindowActive);
        whatShow.text = "Инвентарь";
    }


    public void Switch()
    {
        IsCraftInfoWindowActive = !IsCraftInfoWindowActive;
        craftInfoWindow.SetActive(IsCraftInfoWindowActive);
        inventoryWindow.SetActive(!IsCraftInfoWindowActive);
        whatShow.text = IsCraftInfoWindowActive ? "Инвентарь" : "О сервере";
    }

}
