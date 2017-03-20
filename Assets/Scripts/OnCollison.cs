using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollison : MonoBehaviour {
    public Vector3 respawn;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "PlayerMain" )
        {
            transform.position = respawn;
            print("Player hit!");
        }
    }
}
