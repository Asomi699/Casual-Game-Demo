using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buttonRun;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private Canvas _canvasEndGame;
    
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Fail += OnSwitchCanvas;
        _player.Won += DisableMainCanvas;
    }

    private void OnDisable()
    {
        _player.Fail -= OnSwitchCanvas;
        _player.Won -= DisableMainCanvas;
    }

    public void ClickButtonStart()
    {
        DisableStartPanel();
        ActivateButtonRun();
    }
    
    private void OnSwitchCanvas()
    {
        EnableEndGameCanvas();
        DisableMainCanvas();
    }
    
    private void DisableStartPanel()
    {
        _startPanel.SetActive(false);
    }

    private void ActivateButtonRun()
    {
        _buttonRun.interactable = true;
    }

    private void DisableMainCanvas()
    {
        gameObject.SetActive(false);
    }

    private void EnableEndGameCanvas()
    {
        _canvasEndGame.gameObject.SetActive(true);
    }
}
