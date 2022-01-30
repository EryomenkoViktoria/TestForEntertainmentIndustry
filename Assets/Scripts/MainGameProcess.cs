using UnityEngine;
using EITest.UI.HUD;

namespace EITest.GameProcess
{
    public class MainGameProcess : MonoBehaviour
    {
        internal bool isPaused { get; set; }
        internal int scoreEnemy { get; set; }
        internal int scorePlayer { get; set; }

        private void Start()
        {
            scoreEnemy = PlayerPrefs.GetInt("ScoreEnemy", scoreEnemy);
            scorePlayer = PlayerPrefs.GetInt("ScorePlayer", scorePlayer);
        }

        protected void Kill(int indexPlayer)
        {
            isPaused = true;

            if(indexPlayer == 1)
            {
                scorePlayer++;
                PlayerPrefs.SetInt("ScorePlayer", scorePlayer);
                DisplayUI.inst?.UIScorePlayer();
            }

            if(indexPlayer == 2)
            {
                scoreEnemy++;
                PlayerPrefs.SetInt("ScoreEnemy", scoreEnemy);
                DisplayUI.inst?.UIScoreEnemy();
            }

            PlayerPrefs.Save();

            GameOver();
        }

        protected void GameOver()
        {
            DisplayUI.inst?.GameOver();
        }

        internal void ClearData()
        {
            PlayerPrefs.DeleteAll();

            DisplayUI.inst.scoreDispleyEnemy.text = "0";
            DisplayUI.inst.scoreDispleyPlayer.text = "0";
        }
    }
}