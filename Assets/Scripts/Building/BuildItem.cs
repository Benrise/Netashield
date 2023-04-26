using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName = "Scriptable object/Building/ BuildItem")]
public class BuildItem : ScriptableObject {
    public TileBase tile;
    public Sprite image;
    public ItemType type;
    public bool stackable = true;
    public ActionType actionType;

    
    public Vector2Int range = new Vector2Int(9999999, 9999999);
}

public enum ItemType {
    CraftingItem,
    Tool,
    BuildingBlock
}
public enum ActionType {
    Use,
    
    Craft,
    Quest,

    Build
}






