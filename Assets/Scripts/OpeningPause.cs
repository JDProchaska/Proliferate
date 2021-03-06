﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
namespace ProLifeRate
{
    public class OpeningPause : MonoBehaviour
    {

        private float time = 0f;
        public GameObject player;
        public GameObject playerCamera;
        public GameObject enemy;
        public GameObject cutsceneCamera;
        public GameObject UI;

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;

            if (time > 6.017)
            {
                AfterStart();
            }
            else
            {
                BeforeStart();
            }

        }
        public void BeforeStart()
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<Shoot1>().enabled = false;
            playerCamera.GetComponent<Camera>().enabled = false;
            enemy.GetComponent<AIEnemy>().enabled = false;
            UI.SetActive(false);

        }
        public void AfterStart()
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<Shoot1>().enabled = true;
            playerCamera.GetComponent<Camera>().enabled = true;
            enemy.GetComponent<AIEnemy>().enabled = true;
            cutsceneCamera.GetComponent<AudioListener>().enabled = false;
            UI.SetActive(true);
            cutsceneCamera.GetComponent<Animator>().StopPlayback();
            GetComponent<OpeningPause>().enabled = false;

        }
        public void StartCutSceneCamera()
        {
            cutsceneCamera.GetComponent<Animator>().StartPlayback();
        }
    }
}