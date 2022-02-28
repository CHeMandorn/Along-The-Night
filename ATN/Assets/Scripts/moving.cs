using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
   // private bool t=false;
    public Animator animator;
    public float movingSpeed=1.0f;
    public Vector3 movement;
    public Rigidbody2D rb;

    private void Start()
    {
        /*if(this.transform.localScale.x<0)
        {
            t = true;

        }*/
    }

    void Update()
    {
        
        
        animator.SetFloat("Horizontal", movement.x);
        //movement = new Vector3(Input.GetAxis("Horizontal"),0f);
       // transform.position = transform.position + movement * Time.deltaTime * movingSpeed;*/
        BasicMove();
       
    }

    void BasicMove()
    {
        
        movement = new Vector2(Input.GetAxis("Horizontal"), 0.0f);       
        rb.velocity = new Vector2(movement.x*movingSpeed, movement.y);
    }

   
}
