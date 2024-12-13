using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public StateManager stateManager;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float runSpeed = 3f;
    private Animator animator;

    // class scoped variaable
    private Vector2 movement;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(stateManager.playerInControl)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(movement * speed * runSpeed);
            }
            
            else
            {
                rb.AddForce(movement * speed);
            }
        }
    }

    public void OnMovement(InputValue value)
    {
        // sve the corresponding vector 2
        movement = value.Get<Vector2>();

        // animator setfloat
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}