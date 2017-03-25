using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour
{
    
    public float moveForce = 0f;
    public float shootRate = 0f;
    public float shootForce = 0f;

        public GameObject bullet;
        public Transform gun;

        // Use this for initialization
    void Start()
    {
        
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("SHOT FIRES");
            GameObject go = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
            go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
        }
    }
}
