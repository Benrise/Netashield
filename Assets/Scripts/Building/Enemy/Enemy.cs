using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float speed = 1.5f;

    public int cost = 1;
    [SerializeField]
    private EnemyData data;

    private GameObject player;

    private Health health;





    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();
        SetEnemyValues();
    }

    void Update(){
        Direct();
    }



    private void OnMouseDown()
    {
        this.GetComponent<Health>().Damage(damage);
    }


    private void SetEnemyValues(){
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
        cost = data.cost;
    }

    private void Direct(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        

        if(collider.CompareTag("Player")){
            if (collider.GetComponent<Health>() != null){
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(10000);
            }
        } 
    }

    
}
