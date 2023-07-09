using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;
using Random = UnityEngine.Random;

public class TubeGenerationManager : MonoBehaviour
{

    [SerializeField] private FloatVariable tubeSpeedVariable;
    [SerializeField] private float tubeSpeedInitial;

    [SerializeField] private int maxTubeInList;
    [SerializeField] private Vector2 tubeLifePos;
    [SerializeField] private float spaceBetweenTube;
    [SerializeField] private Vector2 tubeYRange;

    [SerializeField] private GameObject tubePrefab;

    public List<GameObject> tubeList;

    private void RemoveTube()
    {
        var index = 0;
        var indexToRemove = new List<int>();
        
        foreach (var tube in tubeList)
        {
            if (tube.transform.position.x < tubeLifePos.y)
            {
                Destroy(tube.gameObject);
                indexToRemove.Add(index);
            }

        }

        foreach (var i in indexToRemove)
        {
            tubeList.RemoveAt(i);
        }
        
    }

    private void AddTube()
    {
        var pos = new Vector3(0, Random.Range(tubeYRange.x, tubeYRange.y),0);
        if (tubeList.Count == 0) pos.x = tubeLifePos.x;
        else pos.x = tubeList[tubeList.Count - 1].transform.position.x + spaceBetweenTube;

        var newTube = tubePrefab;
        newTube.transform.position = pos;
        
        var test = Instantiate(newTube);
        tubeList.Add(test);

    }

    private void Update()
    {
        if (tubeList.Count < maxTubeInList) AddTube();
        RemoveTube();
    }

    private void Start()
    {
        tubeSpeedVariable.Value = tubeSpeedInitial;
    }
}
