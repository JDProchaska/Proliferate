using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
namespace ProLifeRate
{
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
                if (Time.timeScale != 0)
                {
                    Cursor.visible = false;
                }
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                player.GetComponent<FirstPersonController>().enabled = false;
                player.GetComponent<Shoot1>().enabled = false;
                Cursor.visible = true;

            }

        }
        public void exitGame()
        {
            print("Game Exited");
            Application.Quit();
        }
        public void playerDeath()
        {
            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<Shoot1>().enabled = false;
        }
        public void restartGame()
        {
            print("Game Restarted");
            Cursor.visible = false;
            SceneManager.LoadScene(0);
            GetComponent<OpeningPause>().StartCutSceneCamera();
        }
    }
}
