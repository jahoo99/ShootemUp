using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour, IStart
{
    [SerializeField]private float _moveSpeed = 0.5f;
    private float _offset;
    private Material mat;
    private float _divider = 10f;
    private bool _gameStart = false;
    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    public void GameStart()
    {
        _gameStart = true;
    }
    void Update()
    {
        if (_gameStart)
        {
            _offset += (Time.deltaTime * _moveSpeed) / _divider;
            mat.SetTextureOffset("_MainTex", new Vector2(_offset, 0)); 
        }
    }
}
