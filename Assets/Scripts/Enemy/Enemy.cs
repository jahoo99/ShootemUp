using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 30f;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rb.velocity = new Vector2(-_enemySpeed, 0);
    }
    private void OnEnable()
    {
        Start();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            HealthManager.Instance.HPLoss();
            this.gameObject.SetActive(false);
        }
        if (other.GetComponent<Stopper>())
        {
            this.gameObject.SetActive(false);
        }
    }
}
