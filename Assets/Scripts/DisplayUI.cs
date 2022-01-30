using EITest.GameProcess;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EITest.UI.HUD
{
    public class DisplayUI : MonoBehaviour
    {
        public static DisplayUI inst;

        [SerializeField]
        internal TextMeshProUGUI scoreDispleyEnemy, scoreDispleyPlayer;

        MainGameProcess mainGameProcess;

        [SerializeField]
        private GameObject panelPause;
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private GameObject enemy;

        [SerializeField]
        private Button restartGame;

        [SerializeField]
        private Button menu;

        [SerializeField]
        private Button clearData;

        private void Awake()
        {
            inst = this;
        }

        private void Start()
        {
            mainGameProcess = FindObjectOfType<MainGameProcess>();

            UIScoreEnemy();
            UIScorePlayer();

            restartGame.onClick.AddListener(RestartGame);
            menu.onClick.AddListener(GoMenu);

            clearData.onClick.AddListener(() => mainGameProcess.ClearData());
        }

        internal void UIScoreEnemy()
        {
            scoreDispleyEnemy.text = mainGameProcess.scoreEnemy.ToString();
        }

        internal void UIScorePlayer()
        {
            scoreDispleyPlayer.text = mainGameProcess.scorePlayer.ToString();
        }

        internal void GameOver()
        {
            panelPause.SetActive(true);
            player.SetActive(false);
            enemy.SetActive(false);
        }

        private void GoMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        private void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}