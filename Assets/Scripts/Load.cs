using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    [Header("Load Stats")]
    [SerializeField]
    private int health;
    [SerializeField]
    private float loadPercentage;
    [SerializeField]
    private float loadSpeedModifier;

    [Header("Loading Bar")]
    public Slider healthSlider; 

    private void Update()
    {
        loadPercentage += Time.deltaTime * loadSpeedModifier;
        loadPercentage = Mathf.Clamp(loadPercentage, 0, 100);
        healthSlider.value = loadPercentage/100;
    }
}
