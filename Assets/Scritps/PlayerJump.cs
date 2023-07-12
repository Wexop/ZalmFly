using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] public float jumpPower;
    [SerializeField] public float jumpCd;

    public bool cantDie;

    [SerializeField] private GameEvent playerStartJump;

    private float _lastJump;
    private static readonly int Jump1 = Animator.StringToHash("Jump");
    public bool _playerisDead;
    public bool _firstJump = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _lastJump = jumpCd;
        _rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        _lastJump += Time.deltaTime;
        //if (Input.GetKey(KeyCode.Space)) Jump();
    }

    public void Jump()
    {
        
        if(_playerisDead && !cantDie) return;
        
        if (_firstJump)
        {
            playerStartJump.Raise();
            _firstJump = false;
        }
        
        _rb.simulated = true;
        if (_lastJump < jumpCd) return;
        _lastJump = 0;
        _rb.velocity = new Vector2(0, jumpPower);
        _animator.SetTrigger(Jump1);
    }

    public void OnPlayerDead()
    {
       if(!cantDie) _playerisDead = true;
    }
}
