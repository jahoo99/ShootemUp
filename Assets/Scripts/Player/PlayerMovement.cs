using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _moveSpeed;
    private Rigidbody2D _rb;
    private float _movementY;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _movementY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + new Vector2(0, _movementY) * _moveSpeed *Time.fixedDeltaTime);
    }

}
