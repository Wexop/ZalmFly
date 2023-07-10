using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Variables;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FloatVariable score;
    [SerializeField] private TextMeshProUGUI hiText;
    private float _highScore;


    private void Start()
    {
        score.Value = 0;
        _highScore = PlayerPrefs.GetFloat("HighScore");
        hiText.text = _highScore.ToString();
    }

    public void UpdateScore()
    {
        text.text = score.Value.ToString();
        if (score.Value > _highScore) PlayerPrefs.SetFloat("HighScore", score.Value);
    }
}
