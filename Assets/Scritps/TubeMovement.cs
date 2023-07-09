using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;

public class TubeMovement : MonoBehaviour
{

    [SerializeField] private FloatVariable speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x -= speed.Value * Time.deltaTime;
        transform.position = pos;

    }
}
