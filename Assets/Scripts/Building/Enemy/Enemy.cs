using UnityEngine;
using UnityEngine.Tilemaps;
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


    private WaveSpawner _waveSpawner;

    private float stopTime = 3f;
    private bool isStopped = false;






    public float minWaitTime = 0.5f;
    public float maxWaitTime = 2f;
    public float minSpeed = 3f;
    public float maxSpeed = 7f;

























    void Awake()
    {
        _waveSpawner = WaveSpawner.Instance;
    }

    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
        {
            _waveSpawner.LaunchWave();
        }


    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();
        SetEnemyValues();
    }

    void Update()
    {
        if (player != null)
        {
            if (!isStopped && gameObject != null)
            {
                Direct();
            }
            if (isStopped)
            {
                stopTime -= Time.deltaTime;
                if (stopTime <= 0f)
                {
                    isStopped = false;
                    stopTime = 3f;
                }
            }
        }

    }


    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
        cost = data.cost;
    }

    private void Direct()
    {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                Destroy(gameObject);
            }
        }

        if (collider.CompareTag("Block"))
        {
            isStopped = true;
            this.GetComponent<Health>().Damage(15);
            collider.GetComponent<Tilemap>().ClearAllTiles();
        }

    }


}



