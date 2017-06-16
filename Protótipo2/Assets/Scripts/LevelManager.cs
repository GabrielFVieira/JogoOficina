using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	public GameObject pauseMenu;
    public string nxtLvl;
	private void Start()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

	public void Update()
	{
        if (Application.loadedLevelName == "Level1")
        {
            nxtLvl = "Level2";
        }

        if (Application.loadedLevelName == "Level2")
        {
            nxtLvl = "Level3";
        }
    }

	public void TogglePauseMenu()
	{
		pauseMenu.SetActive (!pauseMenu.activeSelf);

		if (Time.timeScale == 1)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}


	public void ToMenu()
	{
		SceneManager.LoadScene ("MainMenu");
		Time.timeScale = 1;
	}

	public void Restart()
	{
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void NextLevel()
	{
		SceneManager.LoadScene (nxtLvl);
		Time.timeScale = 1;
	}



}
