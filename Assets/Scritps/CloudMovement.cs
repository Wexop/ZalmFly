using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 YPos;
    public Vector2 Speed;
    public float StartX;
    public float maxX;

    private float _actualPosY;
    private float _actualSpeed;
    void Start()
    {
        DefineStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < maxX) DefineStats();
        var pos = transform.position;
        pos.x -= _actualSpeed * Time.deltaTime;
        transform.position = pos;
    }

    void DefineStats()
    {
        _actualSpeed = Random.Range(Speed.x, Speed.y);
        _actualPosY = Random.Range(YPos.x, YPos.y);

        transform.position = new Vector3(StartX, _actualPosY, 0);

    }
}
