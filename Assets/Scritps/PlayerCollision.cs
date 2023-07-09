using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameEvent playerDieEvent;
    [SerializeField] private GameEvent addScoreEvent;
    [SerializeField] private FloatVariable score;

    private float _lastScoreAdderId;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DeadCollider")
        {
            playerDieEvent.Raise();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ScoreAdder" && col.gameObject.GetInstanceID() != _lastScoreAdderId)
        {
            _lastScoreAdderId = col.gameObject.GetInstanceID();
            score.Value += 1;
            addScoreEvent.Raise();
        }
    }
}
