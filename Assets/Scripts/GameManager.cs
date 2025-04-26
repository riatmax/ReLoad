using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Load load;
    public Sumo sumo;
    private bool loadLoaded = false;
    public bool bossLoaded = false;
    private int currentScore;
    public string scoreText;
    private SaveManager sm;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        currentScore = 0;
        sm = FindFirstObjectByType<SaveManager>();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && !loadLoaded)
        {
            load = FindFirstObjectByType<Load>();
            loadLoaded = true;
        }
        if ((loadLoaded && load == null) || (bossLoaded && sumo == null))
        {
            SaveData loadedSave = sm.Load();
            int highScore = loadedSave.score;
            if (currentScore > highScore)
            {
                SaveData save = new SaveData();
                save.score = currentScore;
                sm.Save(save);
                scoreText = "High Score: " + currentScore;
            }
            else
            {
                scoreText = "High Score: " + highScore;
            }
            SceneManager.LoadScene("GameOverScene");
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
