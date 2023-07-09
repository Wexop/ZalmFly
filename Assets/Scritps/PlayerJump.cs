using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpCd;
    private float _lastJump;
    private static readonly int Jump1 = Animator.StringToHash("Jump");
    private bool _playerisDead;

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
        if (!_playerisDead && Input.GetKey(KeyCode.Space)) Jump();
    }

    public void Jump()
    {
        _rb.simulated = true;
        if (_lastJump < jumpCd) return;
        _lastJump = 0;
        _rb.velocity = new Vector2(0, jumpPower);
        _animator.SetTrigger(Jump1);
    }

    public void OnPlayerDead()
    {
        _playerisDead = true;
    }
}
