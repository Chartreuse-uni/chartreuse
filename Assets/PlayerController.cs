// using UnityEditor.XR.LegacyInputHelpers;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 speed = new(2, 2);
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var movement = new Vector3(input.x * speed.x, input.y * speed.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    private void UpdateAnimations()
    {
        if (speed != Vector2.zero)
        {
        }
    }
}