using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    [Header("Animator Setting")]
    [SerializeField] [Tooltip("Debug_Camera_Animator Reference")] Animator animator;
    [SerializeField] [Tooltip("PlayerController Reference")] PlayerController moveController;

    void Awake()
    {
        TryGetComponent(out animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveController.horizontal > 0.2f || moveController.vertical > 0.2f || moveController.horizontal < -0.2f || moveController.vertical < -0.2f) animator.SetBool("isRun", true);
        else animator.SetBool("Isrunning", false);
    }
}
