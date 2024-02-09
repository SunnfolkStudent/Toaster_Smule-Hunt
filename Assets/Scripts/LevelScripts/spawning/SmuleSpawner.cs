using UnityEngine;
using Random = UnityEngine.Random;

public class SmuleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    
    ObjectPooling objectPooling;
    
    private float _timer;

    private void Start()
    {
        objectPooling = ObjectPooling.Instance;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (!(_timer >= _spawnRate)) return;
        _timer = 0;
        objectPooling.SpawnFormPool("smule", FindRandomPosition(), Quaternion.identity);
    }

    private Vector3 FindRandomPosition()
    {
        var randomPos = new Vector3(Random.Range(-9, 9), Random.Range(-5, 5), 0);
        return randomPos;
    }
    
}
