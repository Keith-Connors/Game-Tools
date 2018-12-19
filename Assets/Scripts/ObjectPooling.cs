using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour 
{
    [System.Serializable]
    class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooling Instance;
    
    [SerializeField] private List<Pool> _pools;
    private Dictionary<string, Queue<GameObject>> poolsDictionary;

    private void Awake()
    {
        if (Instance == null) //if the instance is not this
        {
            Instance = this; //make the instance this
        }
        else
        {
            if (Instance != this) //if the instance is not equal to this
            {
                Destroy(this); //destory this.
            }
        }
    }

    private void Start()
    {
        poolsDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in _pools)
        {
            
            //Create queue
            Queue<GameObject> objectPool = new Queue<GameObject>();
            //Instantiate all elements 
            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefab);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }
            //Add to dictionary.
            poolsDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolsDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject go = poolsDictionary[tag].Dequeue(); //take the object from the top of the queue
        go.SetActive(true); //set as active when removed
        go.transform.position = position; //set position
        go.transform.rotation = rotation; //set rotation

        poolsDictionary[tag].Enqueue(go); //queue the object at the bottom of the list
        
        IPoolable objectToPool = go.GetComponent<IPoolable>();
        objectToPool.OnObjectPooled();
        return go; //Jump out when complete.
    }
}
