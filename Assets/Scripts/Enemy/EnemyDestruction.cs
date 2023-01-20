using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour, ITouch
{
    public void Touch()
    {
        ScoreManager.Instance.AddScore();
        Destroy(this.gameObject);
    } 
}
