using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed = 5f;

    // class scoped variaable
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   public void OnMovement(InputValue value){
        // sve the corresponding vector 2
        movement = value.Get<Vector2>();

        // animator setfloat
        if(movement.x != 0  || movement.y != 0){
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);
        animator.SetBool("isWalking", true);
        }else{
        animator.SetBool("isWalking", false);

        }
       

   }

   private void FixedUpdate(){
        // Rigid body velocity physics based
        // rb.MovePosition(rb.position + movement * speed *Time.fixedDeltaTime);
        // if(movement.x != 0  || movement.y != 0){
        // rb.linearVelocity = movement * speed;

        // }

        // use forces to track velocity
        rb.AddForce(movement*speed); 
   }
}
