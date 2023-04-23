using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Inventory/ Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;
    public ActionType actionType;

    [Header("Only UI")]
    public bool stackable = true;


    [Header("Both")]
    public Sprite image;

}


