// using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Vector2 speed = new Vector2(2, 2);
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(input.x * speed.x, input.y * speed.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    void UpdateAnimations()
    {
        if (speed != Vector2.zero)
        {

        }
    }

}
