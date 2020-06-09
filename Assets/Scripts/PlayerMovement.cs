using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    [SerializeField]
    private float forwardMoveSpeed = 100f;
    [SerializeField]
    private float backwardMovepeed = 100f;
    [SerializeField]
    private float turnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        movement = transform.transform.TransformDirection(movement);

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical !=0)
        {
            float moveSpeed = (vertical > 0) ? forwardMoveSpeed : backwardMovepeed;
            characterController.SimpleMove(transform.forward * moveSpeed * Time.deltaTime * vertical);
        }
        

        
    }
}
