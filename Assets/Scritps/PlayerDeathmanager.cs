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
    private float tubeSpeedInit;

    private void Start()
    {
        isDead = false;
        deathCanvas.SetActive(false);
        tubeSpeedInit = tubeSpeed.Value;
    }

    public void OnPlayerDeath()
    {
        tubeSpeed.Value = 0;
        deathCanvas.SetActive(true);
        isDead = true;
    }

    public void OnRestartClick()
    {
        var playerJump = FindObjectOfType<PlayerJump>();
        playerJump._firstJump = true;
        playerJump._playerisDead = false;
        playerJump.transform.position = new Vector3(15, -11, 0);

        var tubeManager = FindObjectOfType<TubeGenerationManager>();
        tubeManager.RemoveAllTube();

        tubeSpeed.Value = tubeSpeedInit;
        Start();

    }
    
}
