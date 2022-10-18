using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // singleton
    public static EnemyManager instance;

    public Enemy[] enemies;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SpawnEnemies(enemies);
    }
    void SpawnEnemies(Enemy[] enemy)
    {
        foreach (Enemy thisenemy in enemy)
        {
            Vector3 spawnPosition = gridManager.GridCordsToWorldCords(thisenemy.spawnCords);
            ObjectPooler.instance.SpwanFromPool(thisenemy.type, spawnPosition, Quaternion.identity);
        }
    }



    
}
