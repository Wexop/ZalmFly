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


    private void Start()
    {
        score.Value = 0;
    }

    public void UpdateScore()
    {
        text.text = score.Value.ToString();
    }
}
