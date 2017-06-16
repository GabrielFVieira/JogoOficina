using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	private static MenuManager instance;
	public static MenuManager Instance{ get { return instance; } }
	public int LevelPassed;
    public int SoundState;
	public float timer;

	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	public void Start()
	{
		if (PlayerPrefs.HasKey("LevelPassed"))
		{
			//We had a previopus session ( Ja jogou antes )
			LevelPassed = PlayerPrefs.GetInt("LevelPassed");
		}

        else
			Save();

        if (PlayerPrefs.HasKey("SoundState"))
        {
            SoundState = PlayerPrefs.GetInt("SoundState");
        }

        else
            PlayerPrefs.SetInt("SoundState", SoundState);
        
    }

	public void Update()
	{
		if (Application.loadedLevelName == "PreMenu") {
			timer += Time.deltaTime;
		}

		if (timer > 2) {
			timer = 0;
			SceneManager.LoadScene ("MainMenu");
		}
	}

	public void Save()
	{
		PlayerPrefs.SetInt("LevelPassed", LevelPassed);
	}
}