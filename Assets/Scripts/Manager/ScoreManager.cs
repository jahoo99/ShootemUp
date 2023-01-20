using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    public int _currentScore =0;

    public void AddScore()
    {
        _currentScore++;
        UpdateUI();
    }
    private void UpdateUI()
    {
        UIManager.Instance.UpdateScore(_currentScore);
    }


}
