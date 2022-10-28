using System;
using Player;
using Singleton;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject player;
    
        [HideInInspector] public int score;

        public void ScoreIncrease()
        {
            score += 1;
            scoreText.text = "Score: " + Convert.ToInt32(score * PointManager.Instance.multiplier);
        }

        public void StartGame()
        {
            player.GetComponent<PlayerController>().enabled = true;
            startPanel.SetActive(false);
        }

        public void GameOver()
        {
            player.GetComponent<PlayerController>().enabled = false;
            PlayerAnimations.Instance.SetAnimation("EndGame", true);
            gameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.GetComponent<PlayerController>().enabled = true;
            startPanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }
    }
}
