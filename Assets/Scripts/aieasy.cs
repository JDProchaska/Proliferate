using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aieasy : MonoBehaviour {

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;

    Rigidbody theRigidBody;
    Renderer myRender;



    // Use this for initialization
    void Start () {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < attackDistance)
        {
            myRender.material.color = Color.red;
            lookAtPlayer();
            attackPlease();
            print("ATTACK");
        }
        
        else if (fpsTargetDistance < enemyLookDistance)
        {
            myRender.material.color = Color.yellow;
           // lookAtPlayer();
          //  print("Look At Player Please ");
        }
        else
        {
            myRender.material.color = Color.blue;
        }

        
	}
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime+damping);
    }
    void attackPlease()
    {
        theRigidBody.transform.forward.Set(0,0,1);
        theRigidBody.AddForce(transform.forward*enemyMovementSpeed);
    }
}
