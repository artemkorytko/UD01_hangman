using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : BasePanel
{
    [SerializeField] private Button menuButton;

    private void Start()
    {
        menuButton.onClick.AddListener(OnMenuButtonClick);
    }
    private void OnDestroy()
    {
        menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }
    private void OnMenuButtonClick()
    {
        GameManager.Instance.ChangeGameState(GameState.Game);
    }
}
