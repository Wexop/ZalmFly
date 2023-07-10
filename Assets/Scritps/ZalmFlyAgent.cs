using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;

public class ZalmFlyAgent : Agent
{

    private PlayerJump _playerJump;
    private TubeGenerationManager _tubeGenerationManager;
    private PlayerDeathmanager _playerDeathmanager;

    public static ZalmFlyAgent instance = null;  

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);   
        }
        GetGameObjects();
    }

    private void GetGameObjects()
    {
        if (!_playerJump) _playerJump = FindObjectOfType<PlayerJump>();
        if (!_tubeGenerationManager) _tubeGenerationManager = FindObjectOfType<TubeGenerationManager>();
        if (!_playerDeathmanager) _playerDeathmanager = FindObjectOfType<PlayerDeathmanager>();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveY = actions.ContinuousActions[0];
        
        if (moveY == 1)
        {
            _playerJump.Jump();

            if (_playerJump._firstJump) SetReward(1f);
            
        }
        
        if (moveY != 1 && _playerJump._firstJump) SetReward(-1f);

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = 0;
        if (Input.GetKey(KeyCode.Space)) continuousActions[0] = 1;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(_playerJump.gameObject.transform);
        var nextTube = _tubeGenerationManager.tubeList.Find((tube) =>
            tube.transform.position.x > _playerJump.gameObject.transform.position.x);
        
        var transforms = nextTube ? nextTube.GetComponentsInChildren<Transform>() : new Transform[]{};
        Vector3 holePos = new Vector3(0,0,0);
        Vector3 afterTubePos = new Vector3(0, 0, 0);

        foreach (var t in transforms)
        {
            sensor.AddObservation(t.position);
        }

        if (nextTube) sensor.AddObservation(nextTube.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AfterTube")) SetReward(1f);
        if(other.gameObject.CompareTag("ScoreAdder")) SetReward(1f);
        if(other.gameObject.CompareTag("DeadCollider")) SetReward(-1f);
    }

    private void Update()
    {
        if (!_playerDeathmanager || !_playerJump || !_tubeGenerationManager) GetGameObjects();
        if(_playerDeathmanager.isDead)
        {
            EndEpisode();
            _playerDeathmanager.OnRestartClick();
        }

    }
}
