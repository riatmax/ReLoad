using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChanger : MonoBehaviour
{
    public TMP_Text tmptext;
    private string text;
    public GameManager gm;

    private void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();
        text = gm.scoreText;
        tmptext.text = text;
    }
}
