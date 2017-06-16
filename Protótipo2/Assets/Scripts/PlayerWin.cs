using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {
	public GameObject player;
	public GameObject winMenu;
	public GameObject HUD;
    public GameObject enemies;
    // Use this for initialization
    void Start () {
		winMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && enemies.transform.childCount == 0) {
			winMenu.SetActive (true);
			HUD.SetActive (false);
			Time.timeScale = 0;

            if (Application.loadedLevelName == "Level1")
            {
                MenuManager.Instance.LevelPassed = 1;
                MenuManager.Instance.Save();
            }

            if (Application.loadedLevelName == "Level2")
            {
                MenuManager.Instance.LevelPassed = 2;
                MenuManager.Instance.Save();
            }
        }
	}
}
