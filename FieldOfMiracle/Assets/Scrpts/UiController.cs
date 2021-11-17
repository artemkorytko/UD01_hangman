using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private MenuPanel menuPanel;
    private GamePanel gamePanel;
    private FailPanel failPanel;
    private WinPanel winPanel;

    private BasePanel currentPanel;

    private void Awake()
    {
        menuPanel = FindObjectOfType<MenuPanel>(true);
        gamePanel = FindObjectOfType<GamePanel>(true);
        failPanel = FindObjectOfType<FailPanel>(true);
        winPanel = FindObjectOfType<WinPanel>(true);
        currentPanel = null;
    }

    public void OnMenuState()
    {
        currentPanel?.Close();
        menuPanel.Open();
        currentPanel = menuPanel;
    }

    public void OnGameState()
    {
        currentPanel?.Close();
        gamePanel.Open();
        currentPanel = gamePanel;
    }

    public void OnWinState()
    {
        currentPanel?.Close();
        winPanel.Open();
        currentPanel = winPanel;
    }

    public void OnFailState()
    {
        currentPanel?.Close();
        failPanel.Open();
        currentPanel = failPanel;
    }
}