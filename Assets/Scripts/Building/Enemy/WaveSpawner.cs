using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1Prefub;
    [SerializeField]
    private GameObject enemy2Prefub;
    [SerializeField]
    private GameObject enemy3Prefub;
    [SerializeField]
    private GameObject enemy4Prefub;

    private float enemy1 = 3.5f;
    private float enemy2 = 4.5f;
    private float enemy3 = 5.5f;
    private float enemy4 = 6.5f;

    public GameObject winWindow;

    public int waveLevel;

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-500f, 500), Random.Range(-600f, 600f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }




    void Start()
    {
        StartCoroutine(spawnEnemy(enemy1, enemy1Prefub));
        StartCoroutine(spawnEnemy(enemy2, enemy2Prefub));
        StartCoroutine(spawnEnemy(enemy3, enemy3Prefub));
        StartCoroutine(spawnEnemy(enemy4, enemy4Prefub));
    }


}