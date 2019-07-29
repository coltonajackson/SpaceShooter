using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool isPause;
    public GameObject pauseMenuUI;
    public GameObject gameViewUI;
    public GameObject quitMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameViewUI.SetActive(true);
        quitMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Quit()
    {
        pauseMenuUI.SetActive(false);
        gameViewUI.SetActive(false);
        quitMenuUI.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameViewUI.SetActive(false);
        quitMenuUI.SetActive(false);
        Time.timeScale = 0f;
        isPause = true;
    }
}
