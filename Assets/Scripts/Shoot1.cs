using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour {

    public Rigidbody rbody;
    public float moveForce = 0f;
    public float shootRate = 0f;
    public float shootForce = 0f;
    public float maxShootDistance = 0f;
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.DrawLine(gun.position, gun.forward * maxShootDistance, Color.red);
            Ray ray = new Ray(gun.position, gun.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxShootDistance))
            {
                print("HIT THE BITCH");
            }
            print("SHOT FIRES");
            
        }
    }
}
