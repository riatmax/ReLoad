using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Load load;
    private bool loadLoaded = false;
    private int currentScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        currentScore = 0;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && !loadLoaded)
        {
            load = FindFirstObjectByType<Load>();
            loadLoaded = true;
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void addScore(int score)
    {
        currentScore += score;
    }
}
