using System.Collections;
using UnityEngine;

public class GettingBlock : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private float moveSpeed;

    private BuildItem item;

    public void Initialize(BuildItem item){
        this.item = item;
        sr.sprite = item.image;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            StartCoroutine(MoveAndCollect(other.transform));
        }
    }
    private IEnumerator MoveAndCollect(Transform target){
        Destroy(collider);

        while (transform.position != target.position){
            transform.position = Vector3.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

        Destroy(gameObject);
    }
    
    
}
