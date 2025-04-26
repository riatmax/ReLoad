using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Load load;
    private float loadP;
    private bool doneSpawning = false;

    [SerializeField]
    private GameObject[] ObjectsToSpawn;

    private void Awake()
    {
        load = FindFirstObjectByType<Load>();
        loadP = load.getLoadPercentage();
    }
    private IEnumerator spawnEnemines()
    {
        while(!doneSpawning)
        {
            int randEnemyOne = Random.Range(0, 1);
            int randEnemyTwo = Random.Range(0, 1);
            
            Instantiate(ObjectsToSpawn[randEnemyOne], )
        }
        
    }
    
}
