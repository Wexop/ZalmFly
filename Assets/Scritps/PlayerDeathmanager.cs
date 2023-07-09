using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;

public class PlayerDeathmanager : MonoBehaviour
{
    [SerializeField] private FloatVariable tubeSpeed;

    public void OnPlayerDeath()
    {
        tubeSpeed.Value = 0;
    }
    
}
