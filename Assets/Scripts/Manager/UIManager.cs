using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private TextMeshProUGUI _hp;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _status;
    [SerializeField] private GameObject _dataPanel;

    public void UpdateScore(int score)
    {
        _currentScore.text = score.ToString();
    }
    public void UpdateHighScore(int highScore)
    {
        _highScore.text = highScore.ToString();
    }
    public void UpdateHP(int HP)
    {
        _hp.text = HP.ToString();
    }
    public void UpdateTime(int time)
    {
        _time.text = time.ToString();
    }
    public void UpdateStatus(string status)
    {
        _status.text = status;
    }
    public void TurnOffDataPanel()
    {
        _dataPanel.SetActive(false);
    }
}
