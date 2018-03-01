using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject doorPrefab;
    public LayerMask mask = -1;
    // Use this for initialization
    void Start () {

        finalDoorSpawn();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finalDoorSpawn()
    {
        Vector3 spawn;
        int randX = Random.Range(50, 400);
        int randY = Random.Range(0, 10);
        int randZ = Random.Range(50, 400);

        spawn.x = randX;
        spawn.y = randY;
        spawn.z = randZ;

        Quaternion lookRespawn = new Quaternion();
        GameObject go = (GameObject)Instantiate(doorPrefab, spawn, lookRespawn);

        RaycastHit hit;
        Ray ray = new Ray(doorPrefab.transform.position + Vector3.up * 100, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            if (hit.collider != null)
            {
                doorPrefab.transform.position.Set(spawn.x, (hit.point.y + 4F), spawn.z);
            }
        }
    }
}
