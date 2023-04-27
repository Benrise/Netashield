using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;

    private static WaveSpawner _instance;
    public static WaveSpawner Instance { get { return _instance; } }
    private int _currentEnemyIndex;
    private int _currentWaveIndex;
    private int _enemiesLeftToSpawn;

    public bool IsLevelEnd;

    public GameObject winWindow;


    private void Awake()
    {
        IsLevelEnd = false;
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    void Start()
    {
        _enemiesLeftToSpawn = _waves[0].WaveSettings.Length;
        LaunchWave();

    }

    private IEnumerator SpawnEnemyInWave()
    {
        if (_enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].SpawnDelay);

            Instantiate(_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].Enemy, _waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].NeededSpawner.transform.position, Quaternion.identity);

            _enemiesLeftToSpawn--;
            _currentEnemyIndex++;

            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (_currentWaveIndex < _waves.Length - 1)
            {
                _currentWaveIndex++;
                _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;
                _currentEnemyIndex = 0;
            }
        }
    }


    public void LaunchWave()
    {
        if (_currentWaveIndex == _waves.Length - 1 && _enemiesLeftToSpawn == 0)
        {
            winWindow.SetActive(true);
            StopCoroutine(SpawnEnemyInWave());
            IsLevelEnd = true;
            return;
        }
        StartCoroutine(SpawnEnemyInWave());
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
    public void LaunchTime()
    {
        Time.timeScale = 1f;
    }

}

[System.Serializable]
public class Waves
{
    [SerializeField] private WaveSettings[] _waveSettings;
    public WaveSettings[] WaveSettings { get => _waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject _enemy;
    public GameObject Enemy { get => _enemy; }

    [SerializeField] private GameObject _neededSpawner;
    public GameObject NeededSpawner { get => _neededSpawner; }

    [SerializeField] private float _spawnDelay;
    public float SpawnDelay { get => _spawnDelay; }

}

