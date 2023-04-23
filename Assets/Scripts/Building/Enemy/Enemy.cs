using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        Direct();
    }

    private void Direct(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(GetComponent<Collider>().CompareTag("Player")){
            if (GetComponent<Collider>().GetComponent<Health>() != null){
                GetComponent<Collider>().GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(10000);
            }
        }   
    }
}
