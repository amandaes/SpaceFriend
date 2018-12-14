using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float jumpForce;
    public float moveForce;
    Animator blueAnim;
    public LayerMask groundLayer;

    Transform currentPlanet;
    Rigidbody2D body;

    // Use this for initialization
    void Start () {     
        
        blueAnim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        PlayerWalk();
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 5f;

        Debug.DrawRay(position, direction, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;

    }



    void PlayerJump()
    {
        if (IsGrounded())
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddRelativeForce(new Vector2(0, jumpForce));
                
                blueAnim.SetBool("isWalking", false);
                Debug.Log("jumping");
            }

            
            Debug.Log("not walking");
        }
        return;
        
    }


     void PlayerWalk()
     {
        if (IsGrounded())
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

            rb.AddRelativeForce(new Vector2(Input.GetAxis("Horizontal") * moveForce, 0));

            if (Input.GetAxis("Horizontal") < 0)
            {
                
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
                    
            blueAnim.SetBool("isWalking", true);
        }
        return;
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

    


