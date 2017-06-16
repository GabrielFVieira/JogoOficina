using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Audio : MonoBehaviour
{
    public GameObject sound;
    public GameObject noSound;
    public AudioSource song;
    public MenuManager menuManager;
    public void Start()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        song = GameObject.Find("MenuManager").GetComponent<AudioSource>();
        sound = GameObject.Find("Sound");
        noSound = GameObject.Find("SoundDesactived");

        if (menuManager.SoundState == 0)
        {
            sound.SetActive(true);
            noSound.SetActive(false);
        }

        if (menuManager.SoundState == 1)
        {
            noSound.SetActive(true);
            sound.SetActive(false);
        }
    }

    public void Update()
    {



        if(sound.activeSelf == true)
        {
            menuManager.SoundState = 0;
            song.volume = 1;
        }
        if(noSound.activeSelf == true)
        {
            menuManager.SoundState = 1;
            song.volume = 0;
        }
    }
}