using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

   private Transform target;
    public float speed;
    //Rigidbody2D rb;
    public float distanceBetween = 3f;

    Transform currentPlanet;
    Rigidbody2D body;

    //bool isFollowing = false;

    public float hurtPlayer = 2f;

    // Use this for initialization
    void Start () {
       // rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        float disToTarget = Vector2.Distance(transform.position, target.position);
        if (disToTarget < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

        UpdatePlanetRotation();


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            HealthBarScript.health -= hurtPlayer;
            Debug.Log("hurt player" + HealthBarScript.health);
        }
        
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            currentPlanet = collision.transform;
            Debug.Log("colliding with planet");
        }
    }

    void UpdatePlanetRotation()
    {
        if (currentPlanet != null)
        {
            Vector2 planetUp = (transform.position - currentPlanet.position).normalized;
            Vector2 planetRight = new Vector2(planetUp.y, -planetUp.x);
            float angleFromPlanetRight = Mathf.Atan2(planetRight.y, planetRight.x) * Mathf.Rad2Deg;
            if (body == null)
            {
                body = GetComponent<Rigidbody2D>();
            }
            body.MoveRotation(angleFromPlanetRight);
        }
    }
}
