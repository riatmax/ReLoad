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

    [Header("Loading Bar")]
    public Slider healthSlider; 

    private void Update()
    {
        // bar load logic
        loadPercentage += Time.deltaTime * loadSpeedModifier;
        loadPercentage = Mathf.Clamp(loadPercentage, 0, 100);
        healthSlider.value = loadPercentage/100;
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
}
