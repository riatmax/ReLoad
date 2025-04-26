using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSpawner : MonoBehaviour
{

    private Load load;
    private bool doneSpawning = false;

    private IEnumerator coroutine;

    [SerializeField]
    public GameObject Popup;

    private void Awake()
    {
        load = FindFirstObjectByType<Load>();
        //loadP = load.getLoadPercentage();
        coroutine = spawnPopups();
        StartCoroutine(coroutine);
    }
    private IEnumerator spawnPopups()
    {
        while(!doneSpawning)
        {
            yield return new WaitForSeconds((float)2.5);
            Instantiate(Popup, getSpawnPos(), Quaternion.identity);

            
        }
        
    }

    private Vector3 getSpawnPos(){
        float radius = 2;

        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector3 spawnPos = new Vector3(load.gameObject.transform.position.x + x,load.gameObject.transform.position.y + y, 0);

        return spawnPos;
    }
}
