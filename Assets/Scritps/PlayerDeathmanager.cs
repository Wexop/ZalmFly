using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathmanager : MonoBehaviour
{
    [SerializeField] private FloatVariable tubeSpeed;
    [SerializeField] private GameObject deathCanvas;
    public bool isDead;

    private void Start()
    {
        deathCanvas.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        tubeSpeed.Value = 0;
        deathCanvas.SetActive(true);
        isDead = true;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
