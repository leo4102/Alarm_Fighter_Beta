using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager
{
    GameObject pauseMenu;


    bool isPause = false;
    public bool IsPause { get { return isPause; }  private set { isPause = value; } }

    public void Init()
    {
        pauseMenu = Managers.Resource.Instantiate("UI/PauseMenuCanvas");
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void Resume()
    {
        isPause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }
}
