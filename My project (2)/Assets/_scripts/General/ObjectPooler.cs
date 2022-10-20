using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPooler : MonoBehaviour
{ 
    [System.Serializable]
    public class Pool
    {
           public string name;
           public GameObject prefab;
           public int size;
    }

    public static ObjectPooler instance;
    [NonReorderable]
    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> newQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                newQueue.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, newQueue);
        }
    }
    public GameObject SpwanFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject obj = poolDictionary[tag].Dequeue();

            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }

}
