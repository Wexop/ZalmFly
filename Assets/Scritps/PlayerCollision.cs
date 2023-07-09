using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameEvent playerDieEvent;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DeadCollider")
        {
            playerDieEvent.Raise();
        }
    }
}
