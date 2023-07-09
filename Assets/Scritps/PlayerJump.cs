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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _lastJump = jumpCd;
    }

    // Update is called once per frame
    void Update()
    {
        _lastJump += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) Jump();
    }

    public void Jump()
    {
        if (_lastJump < jumpCd) return;
        _lastJump = 0;
        _rb.velocity = new Vector2(0, jumpPower);
        _animator.SetTrigger(Jump1);
    }
}
