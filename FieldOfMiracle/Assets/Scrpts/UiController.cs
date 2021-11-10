using System.Collections;
using UnityEngine;

namespace Assets.Scrpts
{
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
            winPanel = FindObjectOfType<WinPanel>(true);
            failPanel = FindObjectOfType<FailPanel>(true);
            currentPanel = null;
        }

        public void OnMenuState()
        {
            currentPanel?.Close();
            menuPanel.Open();
        }
        public void OnGameState()
        {
            currentPanel?.Close();
            gamePanel.Open();
        }
        public void OnWinState()
        {
            currentPanel?.Close();
            winPanel.Open();           
        }
        public void OnFailState()
        {
            currentPanel?.Close();
            failPanel.Open();
        }
    }
}