using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
namespace ProLifeRate
{
    public class EnemyCounter : MonoBehaviour
    {

        private int enemyCounter = 1;
        public Text numberOfEnemys;


        // Use this for initialization
        void Start()
        {
            numberOfEnemys.text = enemyCounter.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            //change color of enemy counter if counter gets high
            if (enemyCounter == 20)
                numberOfEnemys.color = Color.red;
        }

        public void countEnemies(int addNumber)
        {
            enemyCounter+= addNumber;
            numberOfEnemys.text = enemyCounter.ToString();
        }
    }
}