using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SmuleSpawner : MonoBehaviour
{
    [FormerlySerializedAs("_spawnRate")] [SerializeField] private float _spawnRateSmule;
    [SerializeField] private float _spawnRateHazard;
    [SerializeField] private float _minSpawnRateHazard;
    [SerializeField] private float _maxSpawnRateHazard;

    [SerializeField] private AnimationCurve _animationCurve;
    
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
        var randomPos = new Vector3(Random.Range(-14, 14), Random.Range(-8, 8), 0);
        return randomPos;
    }

    private void SpawnSmule()
    {
        _timer += Time.deltaTime;
        if (!(_timer >= _spawnRateSmule)) return;
        _timer = 0;
        objectPooling.SpawnFormPool("smule", FindRandomPosition(), Quaternion.identity);
    }

    private void SpawnHazard()
    {
        _timer2 += Time.deltaTime;
        _spawnRateHazard = Mathf.Lerp(_minSpawnRateHazard, _maxSpawnRateHazard, _animationCurve.Evaluate(_timer2));
        /*if (!(_timer2 >= _spawnRateHazard)) return;
        _timer2 = 0;*/
        objectPooling.SpawnFormPool("hazard", FindRandomPosition(), Quaternion.identity);
    }
}
