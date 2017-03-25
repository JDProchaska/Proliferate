using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseFunctions : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<Shoot1>().enabled = true;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<Shoot1>().enabled = false;
        }

    }
    public void exitGame()
    {
        Application.Quit();
    }
}
