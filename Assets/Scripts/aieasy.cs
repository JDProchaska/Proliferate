using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aieasy : MonoBehaviour
{

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;

    Rigidbody theRigidBody;
    Renderer myRender;

    private bool didRespawn;



    // Use this for initialization
    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance from player
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        //if player is within attack distance
        if (fpsTargetDistance < attackDistance)
        {
            //change color and attack
            myRender.material.color = Color.red;
            lookAtPlayer();
            attackPlease();
            print("ATTACK");
        }
        //if player within look distance
        else if (fpsTargetDistance < enemyLookDistance)
        {
            //change color and look at player
            myRender.material.color = Color.yellow;
            lookAtPlayer();
        }
        else
        {
            //change color
            myRender.material.color = Color.blue;
        }
        //if just respawned and spawn too close
        if (fpsTargetDistance < 20 && didRespawn)
        {
            //spawan again and print to console
            print("TOO CLOSE");
            respawnEnemy();
        }
        else
        {
            //good respawn distance, dont respawn again until collision
            print("SAFE DIDSTANCE");
            didRespawn = false;
        }


    }
    //look at player function
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + damping);
    }
    //attack player function
    void attackPlease()
    {
        theRigidBody.transform.forward.Set(0, 0, 1);
        theRigidBody.AddForce(transform.forward * enemyMovementSpeed);
    }
    //collison detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerMain")
        {
            respawnEnemy();
        }
    }
    //repsawn function
    private void respawnEnemy()
    {
        //declaring respawn vars and setting random values
        Vector3 respawn;
        int randX = Random.Range(50, 400);
        int randY = Random.Range(1, 2);
        int randZ = Random.Range(50, 400);
        //putting random values into the Vector3 respawn item
        respawn.x = randX;
        respawn.y = randY;
        respawn.z = randZ;

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
        //respawn, look at player, print to console to say player hit and also set bool to true for repsawn distance checking
        transform.position = respawn;
        transform.rotation = fpsTarget.rotation;
        print("Player hit!");
        didRespawn = true;
    }
}
