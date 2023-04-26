using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float speed = 1.5f;

    public int cost = 1;
    [SerializeField]
    private EnemyData data;

    private GameObject player;

    private Health health;
    

    private float stopTime = 3f;
    private bool isStopped = false;





    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();
        SetEnemyValues();
    }

    void Update(){
        if(!isStopped && gameObject != null){
            Direct();
        }
        if (isStopped) {
            stopTime -= Time.deltaTime;
            if (stopTime <= 0f) {
                isStopped = false;
                stopTime = 3f;
            }
        }

    }





    private void SetEnemyValues(){
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
        cost = data.cost;
    }

    private void Direct(){
        if (player != null)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.CompareTag("Player")){
            if (collider.GetComponent<Health>() != null){
                collider.GetComponent<Health>().Damage(damage);
                Destroy(gameObject);
            }
        } 

        if (collider.CompareTag("Block")) {
            isStopped = true;
            this.GetComponent<Health>().Damage(15);
        }
    }

    
}
