using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollison : MonoBehaviour {

    public Transform player;
    private void OnCollisionEnter(Collision collision)
    {
        float distance;
        Vector3 respawn;
        int randX = Random.Range(50, 400);
        int randY = Random.Range(2, 4);
        int randZ = Random.Range(50, 400);

        respawn.x = randX;
        respawn.y = randY;
        respawn.z = randZ;

        distance = Vector3.Distance(player.position, transform.position);

        if (collision.gameObject.name == "PlayerMain" )
        {
            /* working on respawn distance checker
            do
            {
                distance = Vector3.Distance(player.position, transform.position);
                randX = Random.Range(50, 400);
                randZ = Random.Range(50, 400);
                respawn.x = randX;
                respawn.z = randZ;
            } while (distance < 20);
            */

            transform.position = respawn;
            print("Player hit!");
        }
    }
}
