using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoSingleton<HealthManager>
{
    private int _maxHP = 3;
    private int _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
        UpdateUI();
    }

    public void HPLoss()
    {
        _currentHP--;
        UpdateUI();
        if (_currentHP <= 0)
        {
            GameManager.Instance.EndGame(false);
        }

    }

    private void UpdateUI()
    {
        UIManager.Instance.UpdateHP(_currentHP);
    }

}
