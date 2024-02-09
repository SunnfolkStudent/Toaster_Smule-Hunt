using UnityEngine;
using Random = UnityEngine.Random;

public class SmuleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _spawnRateHazard;
    
    ObjectPooling objectPooling;
    
    private float _timer;
    private float _timer2;

    private void Start()
    {
        objectPooling = ObjectPooling.Instance;
    }
    
    private void Update()
    {
        SpawnSmule();
        SpawnHazard();
    }

    private Vector3 FindRandomPosition()
    {
        var randomPos = new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 0);
        return randomPos;
    }

    private void SpawnSmule()
    {
        _timer += Time.deltaTime;
        if (!(_timer >= _spawnRate)) return;
        _timer = 0;
        objectPooling.SpawnFormPool("smule", FindRandomPosition(), Quaternion.identity);
    }

    private void SpawnHazard()
    {
        _timer2 += Time.deltaTime;
        if (!(_timer2 >= _spawnRateHazard)) return;
        _timer2 = 0;
        objectPooling.SpawnFormPool("hazard", FindRandomPosition(), Quaternion.identity);
    }
}
