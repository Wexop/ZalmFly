using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZalmFlyRobot : MonoBehaviour
{
    [SerializeField] private bool enabled;

    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private TubeGenerationManager tubeGenerationManager;

    [SerializeField] private float yBeforeGround;
    [SerializeField] private float xBeforeSwitchTube;
    [SerializeField] private float yDelayNextTube;

    private void Update()
    {
        if (!enabled) return;

        var playerPos = playerJump.gameObject.transform.position;
        
        if (tubeGenerationManager.tubeList.Count == 0 || playerPos.y < yBeforeGround) playerJump.Jump();

        var nextTube = tubeGenerationManager.tubeList.Find((tube) =>
            tube.transform.position.x + xBeforeSwitchTube > playerJump.gameObject.transform.position.x);

        var transforms = nextTube.GetComponentsInChildren<Transform>();
        Vector3 holePos = new Vector3(0,0,0);

        foreach (var t in transforms)
        {
            if (t.gameObject.tag == "ScoreAdder") holePos = t.position;
        }
        
        if (playerPos.y < holePos.y + yDelayNextTube) playerJump.Jump();

    }
}