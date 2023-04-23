using UnityEngine;
using UnityEngine.Tilemaps;
public class BuildingSystem : MonoBehaviour
{


     [SerializeField] private BuildItem buildItem;
    [SerializeField] private TileBase highlightTile;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;
    [SerializeField] private GameObject lootPrefab;

    private Vector3Int playerPos;
    private Vector3Int highlightedTilePos;
    private bool highlighted;


    private void Update(){

        playerPos = mainTilemap.WorldToCell(transform.position);
        
        if(buildItem != null){
            HighlightedTile(buildItem);
        }

        if (Input.GetMouseButtonDown(0)){
            if(highlighted){
                if (buildItem.type == ItemType.BuildingBlock){
                    Build(highlightedTilePos, buildItem);
                }
                else if (buildItem.type == ItemType.Tool){
                    Destroy(highlightedTilePos);
                }
            }
        }
    }


    private Vector3Int GetMouseOnGridPos(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = mainTilemap.WorldToCell(mousePos);
        mouseCellPos.z = 0;

        return mouseCellPos;
    }

    private void HighlightedTile(BuildItem currentItem){
        Vector3Int mouseGridPos = GetMouseOnGridPos();

        if(highlightedTilePos != mouseGridPos){
            tempTilemap.SetTile(highlightedTilePos, null);
            if(InRange(playerPos, mouseGridPos, (Vector3Int)currentItem.range)){
                if (CheckCondition(mainTilemap.GetTile<RuleTileWithData>(mouseGridPos), currentItem)){
                    tempTilemap.SetTile(mouseGridPos, highlightTile);
                    highlightedTilePos = mouseGridPos;

                    highlighted = true;
                }
                else {
                    highlighted = false;
                }
            }

            else{
                highlighted = false;
            }

        }
    }



    private bool InRange(Vector3Int positionA, Vector3Int positionB, Vector3Int range){
        Vector3Int distance = positionA - positionB;

        if(Mathf.Abs(distance.x) >= range.x || Mathf.Abs(distance.y) >= range.y){
            return false;
        }

        return true;
    }


    private bool CheckCondition(RuleTileWithData tile, BuildItem currentItem){
        Debug.Log(tile);
        Debug.Log(currentItem);
        if (currentItem.type == ItemType.BuildingBlock){
            if (!tile){
                return true;
            }
        }
        else if(currentItem.type == ItemType.Tool){
            if (tile){
                if (tile.buildItem.actionType == currentItem.actionType){
                    return true;
                }
            }
        }
        return false;
    }


    private void Build(Vector3Int position, BuildItem itemToBuild){

        tempTilemap.SetTile(position, null);
        highlighted = false;

        mainTilemap.SetTile(position, itemToBuild.tile);
    }

    private void Destroy(Vector3Int position){
        tempTilemap.SetTile(position, null);
        highlighted = false;

        RuleTileWithData tile = mainTilemap.GetTile<RuleTileWithData>(position);
        mainTilemap.SetTile(position, null);

        Vector3 pos = mainTilemap.GetCellCenterWorld(position);
        GameObject loot = Instantiate(lootPrefab, pos, Quaternion.identity);
        loot.GetComponent<Loot>().Initialize(tile.buildItem);
        
    }
    
}
