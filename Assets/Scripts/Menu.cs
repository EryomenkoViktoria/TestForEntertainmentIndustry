using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EITest.UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        private Button startGameButton, quitButton;

        private void Start()
        {
            startGameButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitApp);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        private void QuitApp()
        {
            Application.Quit();
        }
    }
}