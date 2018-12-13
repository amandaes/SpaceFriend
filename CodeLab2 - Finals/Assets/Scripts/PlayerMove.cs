using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float jumpForce;
    public float moveForce;
    Animator blueAnim;
    public LayerMask groundLayer;
    
  
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddRelativeForce(new Vector2(0, jumpForce));
                Debug.Log("jumping");
            }

            blueAnim.SetBool("isWalking", false);
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
            blueAnim.SetBool("isWalking", true);
        }
        return;
     }

}

    


