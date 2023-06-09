using System.Collections;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private float moveSpeed;

    private BuildItem buildTtem;

    public void Initialize(BuildItem buildTtem){
        this.buildTtem = buildTtem;
        sr.sprite = buildTtem.image;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){

            bool canAdd = InventoryManager.instance.AddItem(buildTtem);

            if (canAdd){
                StartCoroutine(MoveAndCollect(other.transform));
            }
        }
    }
    private IEnumerator MoveAndCollect(Transform target){
        Destroy(collider);
        while (transform.position != target.position){
            transform.position = Vector3.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }
        Destroy(gameObject);
    }
    
    
}
