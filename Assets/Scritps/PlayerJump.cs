using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpCd;
    private float _lastJump;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _lastJump += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    public void Jump()
    {
        if (_lastJump < jumpCd) return;
        _rb.velocity = new Vector2(0, jumpPower);
    }
}
