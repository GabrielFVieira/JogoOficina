using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject deleteMenu;

    public GameObject deletedText;


    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevelName == "Options")
        {
            deleteMenu = GameObject.Find("DeleteMenu");
            deleteMenu.SetActive(false);
            deletedText = GameObject.Find("Deleted");
            deletedText.SetActive(false);
        }
    }

        // Update is called once per frame
        void Update () {
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Play()
	{
		SceneManager.LoadScene ("LevelSelection");
	}

	public void Credits()
	{
		SceneManager.LoadScene ("Credits");
        deletedText.SetActive(false);
    }

	public void Options()
	{
		SceneManager.LoadScene ("Options");
	}

	public void Back()
	{
		SceneManager.LoadScene ("MainMenu");
        deletedText.SetActive(false);
    }

	public void BackToOptions()
	{
		SceneManager.LoadScene ("Options");
	}

    public void Delete()
    {
        deleteMenu.SetActive(true);
    }

    public void DeleteYes()
    {
        PlayerPrefs.DeleteAll();
        deleteMenu.SetActive(false);
        deletedText.SetActive(true);
    }

    public void DeleteNo()
    {
        deleteMenu.SetActive(false);
    }

	public void Sound()
	{
        
	}

    public void Controls()
    {
    }
}