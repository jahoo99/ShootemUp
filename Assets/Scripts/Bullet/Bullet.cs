using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float _bulletSpeed = 30f;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rb.velocity = new Vector2(_bulletSpeed,0);
    }
    private void OnEnable()
    {
        Start();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<ITouch>() != null)
        {
            ITouch IT = other.GetComponent<ITouch>();
            IT.Touch();
            this.gameObject.SetActive(false);
        }
    }
    
}
