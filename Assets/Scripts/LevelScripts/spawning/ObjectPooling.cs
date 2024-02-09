using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    
    #region
    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    
    [SerializeField]private float _disappearTime = 2;

    private void Start()
    {
        StartCoroutine(IDecreasDisappearTime());
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFormPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool With tag"+ tag +" does not exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        StartCoroutine(DeActivate()); 
        
        IPooledObjekt pooledObj = objectToSpawn.GetComponent<IPooledObjekt>();

        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        
        poolDictionary[tag].Enqueue(objectToSpawn); 
        
        IEnumerator DeActivate()
        {
            yield return new WaitForSeconds(_disappearTime);
            objectToSpawn.SetActive(false);
        }
        return objectToSpawn;
    }

    private IEnumerator IDecreasDisappearTime()
    {
        while (true)
        {
            _disappearTime /= 1.01f;
            yield return new WaitForSeconds(1);
        }
    }
}
