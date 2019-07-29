using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject startMenu;
    public GameObject gameViewUI;
    public GameObject practiceMenu;
    public GameObject player;
    public int totalScore;
    private bool isPractice = false;

	public void PlayGame()
    {
        PlayerPrefs.SetInt("totalScore", totalScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Practice()
    {
        isPractice = !isPractice;
        if (isPractice)
        {
            startMenu.SetActive(false);
            practiceMenu.SetActive(true);
        }
        else {
            startMenu.SetActive(true);
            practiceMenu.SetActive(false);
        }
    }

    public void NextLevel()
    {
        PlayerPrefs.GetInt("totalScore");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        PlayerPrefs.GetInt("totalScore");
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
