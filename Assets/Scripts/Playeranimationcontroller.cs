using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranimationcontroller : MonoBehaviour
{
    [SerializeField] Animator PlayerAnimator = null;
    [SerializeField] GameObject player;
    Rigidbody rb;
    Vector3 forward = new Vector3(0, 0, 1);
    bool IsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    public void PlessedPasteButton()
    {
        PlayerAnimator.SetTrigger("Paste");
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.z > limit)
        //{
        //    IsRunning = true;
        //    PlayerAnimator.SetBool("Isrunning", IsRunning);
        //}
        //else if (rb.velocity.z < -limit)
        //{
        //    IsRunning = true;
        //    PlayerAnimator.SetBool("Isrunning", IsRunning);
        //}
        //else
        //{
        //    IsRunning = false;
        //    PlayerAnimator.SetBool("Isrunning", IsRunning);
        //}

        //if (rb.velocity.x > limit || rb.velocity.z > limit)
        //{
        //    IsRunning = true;
        //    PlayerAnimator.SetBool("Isrunning", IsRunning);
        //}
        //else if (rb.velocity.x < -limit || rb.velocity.z < -limit)
        //{
        //    IsRunning = true;
        //    PlayerAnimator.SetBool("Isrunning", IsRunning);
        //}
        //else
        //{
        //    IsRunning = false;
        //    PlayerAnimator.SetBool("Isrunning", IsRunning);
        //}
        Debug.Log(rb.velocity);
    }
}
