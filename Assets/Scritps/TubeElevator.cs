using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TubeElevator : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private Vector2 yPosMax;

   private Vector3 _firstPos;
   public bool _goUp;

   private void Start()
   {
      _firstPos = transform.position;
      _goUp = Random.Range(1, 2) == 1;
   }

   private void Update()
   {
      if (transform.position.y > yPosMax.y && _goUp) _goUp = false;
      else if (transform.position.y < yPosMax.x && !_goUp) _goUp = true;

      var pos = transform.position;
      var mult = _goUp ? 1 : -1;
      pos.y += (speed * Time.deltaTime) * mult ;
      transform.position = pos;

   }
}
