using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;

    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick); 
        _player.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick); 
        _player.PlayerDied -= OnPlayerDied;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnPlayerDied()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }


    private void OnExitButtonClick()
    {
        Application.Quit();
    }
    
    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
}
