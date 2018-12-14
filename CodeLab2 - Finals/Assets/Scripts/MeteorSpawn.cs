using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

    public GameObject meteor;
    float randX;
    Vector2 spawnPoint;
    public float spawnRate = 2f;
    float nextSpawn = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-6.6f, 140f);
            spawnPoint = new Vector2(randX, transform.position.y);
            Instantiate(meteor, spawnPoint, Quaternion.identity);
            
        }

        Destroy(meteor, 5f);
    }
}
