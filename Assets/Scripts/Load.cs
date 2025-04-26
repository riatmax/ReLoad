using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    [Header("Load Stats")]
    [SerializeField]
    private int health; // loading image health
    [SerializeField]
    private float loadPercentage; // how much the bar is filled
    [SerializeField]
    private float loadSpeedModifier; // how fast bar fills

    [SerializeField]
    private GameObject sumo; // sumo

    [Header("Loading Bar")]
    public Slider healthSlider; 

    private bool sumoSpawned = false;

    private void Update()
    {
        // bar load logic
        loadPercentage += Time.deltaTime * loadSpeedModifier;
        loadPercentage = Mathf.Clamp(loadPercentage, 0, 100);
        healthSlider.value = loadPercentage/100;
        spawnSumo();
        GameOver();
    }
    private void GameOver()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void setHealth(int health)
    {
        this.health = health;
    }
    public int getHealth()
    {
        return this.health;
    } 
    public float getLoadPercentage()
    {
        return this.loadPercentage;
    }

    private void spawnSumo(){
        if(loadPercentage == 100 && sumoSpawned == false){
            Instantiate(sumo, getSpawnPos(), Quaternion.identity);
            sumoSpawned = true;
        }
    }

    private Vector3 getSpawnPos(){
        float radius = 10;

        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector3 spawnPos = new Vector3(transform.position.x + Mathf.Clamp(transform.position.y + y, -5, 5), 0);

        return spawnPos;
    }
}
