using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoSingleton<GameManager>
{
    [Header("Only Game Objects with Type IStart")]
    [SerializeField]private GameObject[] _gameStartActions;
    private float _timeLeft =30;
    private bool _startCondition = false;
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            UIManager.Instance.UpdateHighScore(PlayerPrefs.GetInt("HighScore"));
        }
        else
        {
            UIManager.Instance.UpdateHighScore(0);
        }

        if (PlayerPrefs.HasKey("winData"))
        {
            if(PlayerPrefs.GetString("winData") == "true")
            {
                UIManager.Instance.UpdateStatus("Won");
            }
            else
            {
                UIManager.Instance.UpdateStatus("Lost");
            }
        }
        else
        {
            UIManager.Instance.UpdateStatus("firstGame");
        }
    }
    private void Update()
    {
        if (Input.anyKey && !_startCondition)
        {
            _startCondition = true;
            UIManager.Instance.TurnOffDataPanel();
            foreach (var item in _gameStartActions)
            {
                if (item.GetComponent<IStart>() != null)
                {
                    item.GetComponent<IStart>().GameStart();
                }
            }

        }
        if (_startCondition)
        {
            _timeLeft -= Time.deltaTime;
            UIManager.Instance.UpdateTime((int)_timeLeft);
            if (_timeLeft < 0)
            {
                EndGame(true);
            }
        }
    }
    public void EndGame(bool win)
    {
        if (win)
        {
            PlayerPrefs.SetString("winData", "true");
        }
        else
        {
            PlayerPrefs.SetString("winData", "false");
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (ScoreManager.Instance._currentScore>PlayerPrefs.GetInt("HighScore"))
            {
                SetHighScore();
            }
        }
        else
        {
            SetHighScore();
        }

        SceneManager.LoadScene(0);
    }
    private void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", ScoreManager.Instance._currentScore);
    }
}
