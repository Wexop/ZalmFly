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
    [SerializeField] private float yDelayNextTubeGoDown;

    [SerializeField] private PlayerDeathmanager playerDeathmanager;


    public static ZalmFlyRobot instance = null;  

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

        DontDestroyOnLoad(gameObject);
    }

    private void GetGameObjects()
    {
        if (!playerJump) playerJump = FindObjectOfType<PlayerJump>();
        if (!tubeGenerationManager ) tubeGenerationManager = FindObjectOfType<TubeGenerationManager>();
        if (!playerDeathmanager ) playerDeathmanager = FindObjectOfType<PlayerDeathmanager>();
    }

    private void Update()
    {
        if (!enabled) return;
        
        if (playerDeathmanager.isDead) playerDeathmanager.OnRestartClick();
        
        GetGameObjects();

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

        var isElevator = nextTube.TryGetComponent(out TubeElevator tubeElevator);
        var goingDown = tubeElevator && tubeElevator._goUp;

        var yAdd = (isElevator && !goingDown) ? yDelayNextTubeGoDown : yDelayNextTube;
        
        if (playerPos.y < holePos.y + yAdd ) playerJump.Jump();

    }
}
