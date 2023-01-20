using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]private ObjectPool _op;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _op.SpawnFromPool("Bullet", transform.position,Quaternion.identity);
        }
    }
}
