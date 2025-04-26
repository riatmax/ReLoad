using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Load load;
    private float loadP;
    private bool doneSpawning = false;

    private IEnumerator coroutine;

    [SerializeField]
    private GameObject[] ObjectsToSpawn;

    private void Awake()
    {
        load = FindFirstObjectByType<Load>();
        //loadP = load.getLoadPercentage();
        coroutine = spawnEnemines();
        StartCoroutine(coroutine);
    }
    void Update() {
        loadP = load.getLoadPercentage();
        if (loadP == 100) {
            doneSpawning = true;
        } 
    }
    private IEnumerator spawnEnemines()
    {
        while(!doneSpawning)
        {
            yield return new WaitForSeconds((float)1.75);
            int randEnemyOne = Random.Range(0, 1);
            int randEnemyTwo = Random.Range(0, 1);

            
            Instantiate(ObjectsToSpawn[randEnemyOne], getSpawnPos(), Quaternion.identity);
            Instantiate(ObjectsToSpawn[randEnemyTwo], getSpawnPos(), Quaternion.identity);

            
        }
        
    }

    private Vector3 getSpawnPos(){
        float radius = 15;

        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector3 spawnPos = new Vector3(load.gameObject.transform.position.x + x,load.gameObject.transform.position.y + y, 0);

        return spawnPos;
    }
    
}
