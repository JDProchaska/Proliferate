﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProLifeRate
{
    public class DeathScript : MonoBehaviour
    {

        public GameObject deathScreen;
        public GameObject gameController;
        // Use this for initialization
        void Start()
        {
            deathScreen.SetActive(false);
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy(Clone)")
            {
                deathScreen.SetActive(true);
                print("DEAD!");
                gameController.GetComponent<PauseFunctions>().playerDeath();
            }


        }
        

    }
}
