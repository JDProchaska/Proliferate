﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour {

    public Rigidbody rbody;
    public float moveForce = 0f;
    public float shootRate = 0f;
    public float shootForce = 0f;
    private float shootRateTimeStamp = 0f;

    public GameObject bullet;
    public Transform gun;
    
	// Use this for initialization
	void Start () {
        rbody.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal") * moveForce;
        float v = Input.GetAxisRaw("Vertical") * moveForce;

        rbody.velocity = new Vector3(h,v,0);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            print("SHOT FIRES");
            GameObject go = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
            go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
            shootRateTimeStamp = Time.time + shootRate;
        }
    }
}
