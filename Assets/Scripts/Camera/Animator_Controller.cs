using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    [Header("Animator Setting")]
    [SerializeField] [Tooltip("Debug_Camera_Animator Reference")] Animator animator;
    [SerializeField] [Tooltip("PlayerController Reference")] PlayerController moveController;
    [SerializeField] JumpManager JumpManager;
    Rigidbody rb;
    float state = 0.1f;

    void Awake()
    {
        TryGetComponent(out animator);
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveController.horizontal > state ||
            moveController.vertical > state ||
            moveController.horizontal < -state ||
            moveController.vertical < -state)
        {
            animator.SetBool("isRun", true);
        }
        else animator.SetBool("isRun", false);

        //if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        //{
        //    canJum = false;
        //    animator.Play("Up");
        //}

        if (rb.velocity.y > state)
        {
            animator.SetBool("isJump", true);
        }
        else animator.SetBool("isJump", false);

        if (rb.velocity.y < -state)
        {
            animator.SetBool("isFall", true);
        }
        else animator.SetBool("isFall", false);

        if(Input.GetKeyDown(KeyCode.P))
        {
            animator.Play("dead");
        }
    }
}
