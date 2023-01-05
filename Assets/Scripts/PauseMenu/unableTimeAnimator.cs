using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unableTimeAnimator : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}
